using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace F1GrandPrixApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : Controller
    {
        private IZoneRepository zoneRepository;
        public ZoneController(IZoneRepository zoneRepository)
        {
            this.zoneRepository = zoneRepository;
        }

        [HttpGet("zone")]
        public IActionResult UcitajZone()
        {
            var zone = zoneRepository.UcitajZone();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(zone);
        }

        [HttpGet("{zonaId}")]
        public IActionResult UcitajZonu(int zonaId)
        {
            if (!zoneRepository.PostojiZona(zonaId))
                return NotFound();

            var zona = zoneRepository.UcitajZonu(zonaId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(zona);
        }
    }
}
