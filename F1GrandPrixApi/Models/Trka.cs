namespace F1GrandPrixApi.Models
{
    public class Trka
    {
        public int id { get; set; }
        public DateTime datumOdrzavanja { get; set; }
        public string lokacija { get; set; }
        public string dodatneInformacije { get; set; }

        public Grad grad { get; set; }
        public List<Ucesce> ucesca { get; set; }
        public List<Rezervacija> rezervacije { get; set; }

        public string nazivSlike { get; set; }
    }
}
