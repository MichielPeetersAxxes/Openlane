using Domain;

namespace Openlane.Domain
{
    public class Bid
    {
        public int Id { get; set; }
        public string BikeId { get; set; }
        public Bike Bike { get; set; }
    }
}
