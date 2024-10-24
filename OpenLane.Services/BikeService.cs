using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Openlane.DAL;
using Openlane.Shared.Interfaces;

namespace Openlane.Services
{
    public class BikeService : IBikeService
    {
        private readonly Openlanecontext _db;
        private readonly IMapper _mapper;

        public BikeService(Openlanecontext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task HandleBikeDeletion(string id)
        {
            var bike = await _db.Bikes.Where(o => o.Id == id).FirstOrDefaultAsync();

            if (bike != null)
            {
                _db.Bikes.Remove(bike);
                await _db.SaveChangesAsync();
            }
        }

        public async Task HandleBikeUpdate(string id)
        {
            var bikeListDTO = await ClientFetcher.Fetch();

            var bike = bikeListDTO.Values.Where(o => o.Id == id).FirstOrDefault();

            if (bike != null)
            {
                var updatedBike = _mapper.Map<Bike>(bike);
                _db.Bikes.Update(updatedBike);
                await _db.SaveChangesAsync();
            }
        }
    }
}
