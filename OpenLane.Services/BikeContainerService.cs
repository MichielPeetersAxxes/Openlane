using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Openlane.DAL;
using Openlane.Domain;
using Openlane.Shared.Interfaces;

namespace Openlane.Services;

public class BikeContainerService : IBikeContainerService
{
    private readonly Openlanecontext _db;
    private readonly IMapper _mapper;

    public BikeContainerService(Openlanecontext db, IMapper mapper)
    {
        this._db = db;
        this._mapper = mapper;
    }

    public async Task HandleContainerDeletion(string id)
    {
        var container = await _db.BikeContainers.Where(o => o.Id == id).FirstOrDefaultAsync();

        if (container != null)
        {
            _db.BikeContainers.Remove(container);
            await _db.SaveChangesAsync();
        }
    }

    public async Task HandleContainerPublish(string id)
    {
        var bikeListDTO = await ClientFetcher.Fetch(id);

        var container = new BikeContainer()
        {
            Id = id,
            Bikes = _mapper.Map<List<Bike>>(bikeListDTO.Values),
        };

        _db.BikeContainers.Add(container);
        await _db.SaveChangesAsync();
    }
}
