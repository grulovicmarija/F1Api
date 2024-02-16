namespace F1GrandPrixApi.DataTransferObjects
{
    public class RezervacijaSendDto
    {
        public int popust { get; set; }
        public decimal konacnaCena { get; set; }
        public int KupacId { get; set; }
        public int TrkaId { get; set; }
        public int ZonaId { get; set; }
        public string token { get; set; }
        public bool aktivna { get; set; }
        public int brojKarata { get; set; }

        public KupacDto Kupac { get; set; }
        public TrkaDto Trka { get; set;  }
        public ZonaDto Zona { get; set; }
    }
}
