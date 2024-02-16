namespace F1GrandPrixApi.Models
{
    public class Ucesce
    {
        public int id { get; set; }
        public int UcesnikId { get; set; }
        public int TrkaId { get; set; }
        public Trka trka { get; set; }
        public Ucesnik ucesnik { get; set; }
    }
}
