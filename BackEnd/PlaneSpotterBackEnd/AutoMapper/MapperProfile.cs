using AutoMapper;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.Request;
using PlaneSpotterBackEnd.Models.Response;

namespace PlaneSpotterBackEnd.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<AircraftType, AircraftTypeResponse>();
            CreateMap<AircraftTypeRequest, AircraftType>();
            CreateMap<Aircraft, AircraftResponse>();
            CreateMap<AircraftRequest, Aircraft>();
            CreateMap<Sighting, SightingResponse>();
            CreateMap<SightingRequest, Sighting>();
        }
    }
}
