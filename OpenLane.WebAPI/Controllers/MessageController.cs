using Microsoft.AspNetCore.Mvc;
using Openlane.Services;
using Openlane.Shared;
using Openlane.Shared.Interfaces;

namespace Openlane.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IBikeContainerService _bikeContainerService;
        private readonly IBikeService _bikeService;
        private readonly IBidService _bidService;

        public MessageController(IBikeContainerService bikeContainerService, IBikeService bikeService, IBidService bidService)
        {
            this._bikeContainerService = bikeContainerService;
            this._bikeService = bikeService;
            this._bidService = bidService;
        }

        [HttpPost]
        public async Task<IActionResult> HandleClientMessage([FromBody] RequestDataDTO requestDataDTO)
        {
            try
            {
                switch (requestDataDTO.Type.ToUpper())
                {
                    case "BIKECONTAINER.PUBLISHED":
                        await _bikeContainerService.HandleContainerPublish(requestDataDTO.ResourceData.Id);
                        break;
                    case "BIKECONTAINER.REMOVED":
                        await _bikeContainerService.HandleContainerDeletion(requestDataDTO.ResourceData.Id);
                        break;
                    case "BIKE.REMOVED":
                        await _bikeService.HandleBikeDeletion(requestDataDTO.ResourceData.Id);
                        break;
                    case "BIKE.UPDATED":
                        await _bikeService.HandleBikeUpdate(requestDataDTO.ResourceData.Id);
                        break;
                    default: return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Message: " + ex.Message);
            }
        }

        [HttpPost("{bikeId}/bid")]
        public async Task<IActionResult> HandleBidOnBike(string bikeId)
        {
            try
            {
                await _bidService.HandleBidOnBike(bikeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Message: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<BikeListDTO> GetBikesFromContainer(string? bikeContainerId)
        {
            return await ClientFetcher.Fetch(bikeContainerId);
        }
    }
}
