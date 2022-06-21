namespace CityAppAdmin.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
        public string Message { get; set; }

    }
}
