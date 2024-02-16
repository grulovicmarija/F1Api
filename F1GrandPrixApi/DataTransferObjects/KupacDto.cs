using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.DataTransferObjects
{
    public class KupacDto
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
        public bool promoPopust { get; set; }
        public DrzavaDto drzava { get; set; }
    }
}
