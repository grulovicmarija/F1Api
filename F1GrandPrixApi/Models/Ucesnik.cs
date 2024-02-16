namespace F1GrandPrixApi.Models
{
    public class Ucesnik
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public List<Ucesce> ucesca { get; set; }
        public string nazivSlikeUcesnika { get; set; }
        public Drzava? drzava { get; set; }
        public string status { get; set; }
        public int rang { get; set; }

    }
}
