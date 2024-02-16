using AutoMapper;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.DataTransferObjects; 
using Microsoft.AspNetCore.Mvc;
using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrkeController : Controller
    {
        private ITrkeRepository trkeRepository;
        private IMapper mapper; 

        public TrkeController(ITrkeRepository trkeRepository, IMapper mapper)
        {
            this.trkeRepository = trkeRepository;
            this.mapper = mapper;
        }

        [HttpGet("trke")]
        public IActionResult UcitajTrke()
        {
            var trke = trkeRepository.UcitajTrke();
            var trkeDto = mapper.Map<List<TrkaDto>>(trke);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(trkeDto);
        }


        [HttpGet("{trkaId}")]
        public IActionResult UcitajTrku(int trkaId)
        {
            if (!trkeRepository.PostojiTrka(trkaId))
                return NotFound();

            var trka = trkeRepository.UcitajTrku(trkaId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(trka);
        }

        [HttpGet("ucesca/{trkaId}")]
        public IActionResult UcitajUcesca(int trkaId)
        {
            if (!trkeRepository.PostojiTrka(trkaId))
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Ucesce> ucesca = trkeRepository.UcitajUcesca(trkaId);

            return Ok(ucesca); 
        }


    }
}
