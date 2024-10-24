using Openlane.Shared;
using System.Text.Json;

namespace Openlane.Services
{
    public static class ClientFetcher
    {

        public static async Task<BikeListDTO> Fetch(string bikeContainerId = null)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7054/api/Bikes?BikeContainerId={bikeContainerId}");
            response.EnsureSuccessStatusCode();

            var bikes = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var bikeList = JsonSerializer.Deserialize<BikeListDTO>(bikes, options);

            if (bikeList == null)
            {
                return new BikeListDTO();
            }

            return bikeList;
        }
    }
}
