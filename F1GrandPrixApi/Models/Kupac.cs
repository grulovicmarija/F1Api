namespace F1GrandPrixApi.Models
{
    public class Kupac
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string? kompanija { get; set; }
        public string adresa1 { get; set; }
        public string? adresa2 { get; set; }
        public int postanskiBroj { get; set; }
        public string mesto { get; set; }
        public string email { get; set; }
        public string sifra { get; set; }
        public string potvrdaEmailAdrese { get; set; }
        public string promoKod { get; set; }
        public bool iskoriscenPromoKod { get; set; }

        public bool promoPopust { get; set;  }

        public Drzava drzava { get; set; }
        public List<Rezervacija> rezervacije { get; set; }
    }
}
