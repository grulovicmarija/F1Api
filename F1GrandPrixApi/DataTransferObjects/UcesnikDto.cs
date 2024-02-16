using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.DataTransferObjects
{
    public class UcesnikDto
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string nazivSlikeUcesnika { get; set; }
        public Drzava? drzava { get; set; }
        public string status { get; set; }
        public int rang { get; set; }
    }
}
