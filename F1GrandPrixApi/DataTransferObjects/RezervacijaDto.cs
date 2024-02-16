using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.DataTransferObjects
{
    public class RezervacijaDto
    {
        public int popust { get; set; }
        public decimal konacnaCena { get; set; }
        public int KupacId { get; set; }
        public int TrkaId { get; set; }
        public int ZonaId { get; set; }
        public string token { get; set; }
        public bool aktivna { get; set; }
        public int brojKarata { get; set; }

    }
}
