using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string BikeId { get; set; }
        public Bike Bike { get; set; }
    }
}
