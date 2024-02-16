namespace F1GrandPrixApi.Models
{
    public class Drzava
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public List<Kupac> kupci { get; set; }
    }
}
