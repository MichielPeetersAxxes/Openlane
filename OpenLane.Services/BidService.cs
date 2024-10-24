using Openlane.DAL;
using Openlane.Domain;
using Openlane.Shared;
using Openlane.Shared.Interfaces;
using System.Text.Json;

namespace Openlane.Services
{
    public class BidService : IBidService
    {
        private readonly Openlanecontext _db;
        private readonly IHttpClientFactory _client;

        public BidService(Openlanecontext db, IHttpClientFactory client)
        {
            this._db = db;
            this._client = client;
        }

        public async Task HandleBidOnBike(string id)
        {
            var client = _client.CreateClient();

            var response = await client.PostAsync($"https://localhost:7054/api/Bikes/{id}/bid", null);
            response.EnsureSuccessStatusCode();

            var bid = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var bidDTO = JsonSerializer.Deserialize<BidDTO>(bid, options);

            if (bidDTO != null && bidDTO.BidAccepted)
            {
                var newBid = new Bid()
                {
                    BikeId = id
                };
                _db.Bids.Add(newBid);
                await _db.SaveChangesAsync();
            }
        }
    }
}
