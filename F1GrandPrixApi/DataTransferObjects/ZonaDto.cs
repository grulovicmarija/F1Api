namespace F1GrandPrixApi.DataTransferObjects
{
    public class ZonaDto
    {
        public int id { get; set; }
        public string naziv { get; set; }

        public int kapacitet { get; set; }
        public decimal cenaKarte { get; set; }
        public bool pogodnaZaInvalide { get; set; }
        public bool velikiTV { get; set; }
    }
}
