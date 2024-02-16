using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.DataTransferObjects
{
    public class TrkaDto
    {
        public int id { get; set; }
        public DateTime datumOdrzavanja { get; set; }
        public string? lokacija { get; set; }
        public string dodatneInformacije { get; set; }
        public GradDto grad { get; set; }
    }
}
