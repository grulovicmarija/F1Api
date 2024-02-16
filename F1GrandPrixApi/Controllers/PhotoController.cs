using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace F1GrandPrixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : Controller
    {
        ITrkeRepository trkeRepository;
        IUcesniciRepository ucesniciRepository;

        public PhotoController(ITrkeRepository trkeRepository, IUcesniciRepository ucesniciRepository)
        {
            this.trkeRepository = trkeRepository;
            this.ucesniciRepository = ucesniciRepository;
        }

        [HttpGet("{trkaId}")]
        public IActionResult UcitajSlikuTrke(int trkaId)
        {
            var trka = trkeRepository.UcitajTrku(trkaId);
            if (trka.nazivSlike == null) return null;

            string putanja = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", trka.nazivSlike);

            if (!System.IO.File.Exists(putanja))
                return null; 

           
            return File(System.IO.File.OpenRead(putanja), "application/pdf");
        }

        [HttpGet("{ucesnikId}/ucesnik")]
        public IActionResult UcitajSlikuUcesnika(int ucesnikId)
        {
            var ucesnik = ucesniciRepository.UcitajUcesnika(ucesnikId);
            if (ucesnik.nazivSlikeUcesnika == null) return null;

            string putanja = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ucesnik.nazivSlikeUcesnika);

            if (!System.IO.File.Exists(putanja))
                return null;


            return File(System.IO.File.OpenRead(putanja), "application/pdf");
        }
    }
}
