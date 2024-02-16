using AutoMapper;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using F1GrandPrixApi.Repository;

namespace F1GrandPrixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcesniciController : Controller
    {
        private IUcesniciRepository ucesniciRepository;
        private IMapper mapper;

        public UcesniciController(IUcesniciRepository ucesniciRepository, IMapper mapper)
        {
            this.ucesniciRepository = ucesniciRepository;
            this.mapper = mapper;
        }

        [HttpGet("ucesnici")]
        public IActionResult UcitajUcesnike()
        {
            var ucesnici = ucesniciRepository.UcitajUcesnike();
            var ucesniciDto = mapper.Map<List<UcesnikDto>>(ucesnici);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ucesniciDto);
        }

        [HttpGet("{ucesnikId}")]
        public IActionResult UcitajUcesniks(int ucesnikId)
        {
            if (!ucesniciRepository.PostojiUcesnik(ucesnikId))
                return NotFound();

            var trka = ucesniciRepository.UcitajUcesnika(ucesnikId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(trka);
        }
    }
}
