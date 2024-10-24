using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Taxes
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
        public string BikeId { get; set; }
        public Bike Bike { get; set; }
    }
}
