using AutoMapper;
using Domain;
using Openlane.Shared;

namespace Openlane.WEBAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BikeDTO, Bike>()
                .ForMember(destination => destination.Documents,
                    option => option.MapFrom(source => source.Documents))
                .ForMember(destination => destination.Taxes,
                    option => option.MapFrom(source => source.Taxes));

            CreateMap<DocumentDTO, Document>();
            CreateMap<TaxesDTO, Taxes>();
        }
    }
}
