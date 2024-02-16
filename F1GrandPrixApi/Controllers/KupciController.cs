using AutoMapper;
using F1GrandPrixApi.DataTransferObjects;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace F1GrandPrixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupciController : Controller
    {
        private IKupciRepository kupciRepository;
        private IMapper mapper;

        public KupciController(IKupciRepository kupciRepository, IMapper mapper)
        {
            this.kupciRepository = kupciRepository;
            this.mapper = mapper;
        }

        [HttpGet("kupci")]
        public IActionResult UcitajKupce()
        {
            var kupci = kupciRepository.UcitajKupce();
            var kupciDto = mapper.Map<List<KupacDto>>(kupci);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(kupciDto);
        }

        [HttpGet("drzave")]
        public IActionResult UcitajDrzave()
        {
            var drzave = kupciRepository.UcitajDrzave();
            return Ok(drzave);
        }

        [HttpGet("{kupacId}")]
        public IActionResult UcitajKupca(int kupacId)
        {
            if (!kupciRepository.PostojiKupac(kupacId))
                return NotFound();

            var kupac = kupciRepository.UcitajKupca(kupacId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(kupac);
        }

        [HttpPost("/login")]
        public IActionResult UlogujKupca([FromBody] KupacLogin kupacLogin)
        {
            string email = kupacLogin.Email; 
            string sifra = kupacLogin.Sifra;

            if (email == null || email=="" || sifra==null || sifra == "")
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KupacDto kupac = mapper.Map<KupacDto>(kupciRepository.UlogujKupca(email, sifra));

            if (kupac == null)
                return NotFound();

            return Ok(kupac); 
            
        }

        [HttpPost]
        public IActionResult KreirajKupca([FromBody] KupacDto kupacDto)
        {
            if (kupacDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //ne kreiramo ako vec postoji kupac sa istom mail adresom 
            if (kupciRepository.ZauzetMejl(kupacDto.email))
                return BadRequest("You already have an account");

            var kupac = mapper.Map<Kupac>(kupacDto);
            kupac.drzava = kupciRepository.UcitajDrzavu(kupac.drzava.id);
            kupac.promoKod = GenerisiPromoKod();
            

            if(!kupciRepository.KreirajKupca(kupac))
                return BadRequest(ModelState);

            return Ok(kupac);
        }

        [HttpGet("/promoKod/{kupacId}/{promoKod}")]
        public IActionResult IskoristiPromoKod(int kupacId, string promoKod)
        {
            if (!kupciRepository.PostojiKupac(kupacId))
                return NotFound();

            bool uspesno = kupciRepository.IskoristiPromoKod(kupacId, promoKod);

            if (uspesno) return Ok();

            return BadRequest(); 
        }

        private string GenerisiPromoKod()
        {
            Random random = new Random(); 

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string kod = "";

            do
            {
                for (int i = 0; i < 16; i++)
                {
                    kod += chars[random.Next(chars.Length)];
                };

            } while (kupciRepository.ZauzetPromoKod(kod));

            return kod;
        }



    }
}

