using Microsoft.AspNetCore.Mvc;
using Openlane.Shared;
using System.Text.Json;

namespace Openlane.STUB.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBikes([FromQuery] string? bikeContainerId)
        {
            try
            {
                var bikes = System.IO.File.ReadAllText("GET_Bikes.json");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var bikeList = JsonSerializer.Deserialize<BikeListDTO>(bikes, options);

                if (bikeList == null)
                {
                    return BadRequest();
                }

                if (bikeContainerId != null)
                {
                    bikeList.Values = bikeList.Values.Where(b => b.BikeContainerId.Equals(bikeContainerId)).ToList();
                }

                return Ok(bikeList);

            }
            catch (FileNotFoundException ex)
            {
                return NotFound("File GET_bikes.json was not found, message: " + ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{bikeId}/bid")]
        public IActionResult BidOnBike(string bikeId)
        {
            var isAccepted = new Random().Next(2) == 1;

            return Ok(new { BidAccepted = isAccepted });

        }
    }
}
