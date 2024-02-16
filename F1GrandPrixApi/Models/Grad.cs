namespace F1GrandPrixApi.Models
{
    public class Grad
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public List<Trka> trke { get; set; }
    }
}
