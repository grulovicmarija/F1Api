namespace F1GrandPrixApi.Models
{
    public class Rezervacija
    {
        public int popust { get; set; }
        public decimal konacnaCena { get; set; }
        public int KupacId { get; set; }
        public int TrkaId { get; set; }
        public int ZonaId { get; set; }
        public string token { get; set; }
        public bool aktivna { get; set; }
        public int brojKarata { get; set; }
        public Zona zona { get; set; }
        public Kupac kupac { get; set; }
        public Trka trka { get; set; }
    }
}
