using Domain;
using System.ComponentModel.DataAnnotations;

namespace Openlane.Domain
{
    public class BikeContainer
    {
        [Key]
        public string Id { get; set; }
        public List<Bike> Bikes { get; set; }

    }
}
