namespace F1GrandPrixApi.Models
{
    public class Zona
    {
        public int id { get; set; }
        public string naziv { get; set; }

        public int kapacitet { get; set; }
        public decimal cenaKarte { get; set; }
        public bool pogodnaZaInvalide { get; set; }
        public bool velikiTV { get; set; }
        public int preostaloMesta { get; set; }
        public List<Rezervacija> rezervacije { get; set; }
    }
}
