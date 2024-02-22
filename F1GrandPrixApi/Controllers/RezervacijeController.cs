using AutoMapper;
using F1GrandPrixApi.DataTransferObjects;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using F1GrandPrixApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace F1GrandPrixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijeController : Controller
    {
        IRezervacijaRepository rezervacijaRepository;
        IKupciRepository kupciRepository;
        ITrkeRepository trkeRepository;
        IZoneRepository zoneRepository;
        IMapper mapper;

        public RezervacijeController(IRezervacijaRepository rezervacijaRepository,
            IKupciRepository kupciRepository, ITrkeRepository trkeRepository,
            IZoneRepository zoneRepository, IMapper mapper)
        {
            this.rezervacijaRepository = rezervacijaRepository;
            this.kupciRepository = kupciRepository;
            this.trkeRepository = trkeRepository;
            this.zoneRepository = zoneRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult KreirajRezervaciju([FromBody] RezervacijaDto rezervacijaDto)
        {
            if (rezervacijaDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rezervacija rezervacija = mapper.Map<Rezervacija>(rezervacijaDto);

            if (!trkeRepository.PostojiTrka(rezervacija.TrkaId) ||
                !kupciRepository.PostojiKupac(rezervacija.KupacId) ||
                !zoneRepository.PostojiZona(rezervacija.ZonaId))
            {
                return NotFound();
            }

            if (rezervacijaRepository.PostojiRezervacija(rezervacija.KupacId, rezervacija.TrkaId))
                return BadRequest("Reservation already exists."); 


            rezervacija.trka = trkeRepository.UcitajTrku(rezervacija.TrkaId);
            rezervacija.kupac = kupciRepository.UcitajKupca(rezervacija.KupacId);
            rezervacija.zona = zoneRepository.UcitajZonu(rezervacija.ZonaId);

            //rezervacija.popust = 0;
            //List<Rezervacija> rezervacijeKupca = kupciRepository.UcitajRezervacijeKupca(rezervacija.KupacId);
            //foreach(Rezervacija rez in rezervacijeKupca)
            //{ 
            //    rezervacija.popust += 10;
            //}

            rezervacija.konacnaCena = rezervacija.brojKarata * rezervacija.zona.cenaKarte;

            if (DateTime.Now <= rezervacija.trka.datumOdrzavanja.AddDays(-14))
            {
                rezervacija.konacnaCena *= 0.9m;
            }

            Random random = new Random();
            rezervacija.token = random.Next(100000, 9999999).ToString();
            rezervacija.aktivna = true;



            //provera da li je preostalo mesta u zoni 
            if (!zoneRepository.Dostupna(rezervacija.ZonaId))
                return BadRequest(ModelState);


            if (!rezervacijaRepository.KreirajRezervaciju(rezervacija))
                return BadRequest(ModelState);


            zoneRepository.SmanjiMesto(rezervacija.ZonaId, rezervacija.brojKarata);


            return Ok(rezervacija);
        }

        [HttpPost("/azuriranjeRezervacije")]
        public IActionResult AzurirajRezervaciju(RezervacijaDto rezervacijaDto)
        {
            if (rezervacijaDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!rezervacijaRepository.PostojiRezervacija(rezervacijaDto.KupacId, rezervacijaDto.TrkaId))
                return NotFound();

            var rezervacija = mapper.Map<Rezervacija>(rezervacijaDto);

            if (!rezervacijaRepository.AzurirajRezervaciju(rezervacija))
                return BadRequest(ModelState);
            
            return Ok(rezervacija);
        }


        [HttpDelete("/token/{token}/{email}")]
        public IActionResult OtkaziRezervaciju(string token, string email)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rezervacija rezervacija = rezervacijaRepository.UcitajRezervacijuPremaTokenu(email, token);

            if (rezervacija == null)
                return NotFound();

            

            rezervacijaRepository.OtkaziRezervaciju(rezervacija);
            rezervacijaRepository.PonovoObracunajPopust(rezervacija.KupacId); 

            return Ok(); 
        }

        [HttpGet("/kupac/{kupacId}")]
        public IActionResult UcitajRezervacijeKupca(int kupacId)
        {
            if(!kupciRepository.PostojiKupac(kupacId))
            {
                return NotFound(); 
            }

            List<Rezervacija> rezervacije = rezervacijaRepository.UcitajRezervacijeKupca(kupacId);
            List<RezervacijaSendDto> rezervacijeSend = mapper.Map<List<RezervacijaSendDto>>(rezervacije);

            return Ok(rezervacijeSend);
        }

    }
}
