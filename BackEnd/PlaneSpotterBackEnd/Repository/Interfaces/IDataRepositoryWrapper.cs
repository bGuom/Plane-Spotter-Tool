using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public interface IDataRepositoryWrapper
    {
        IUserRepository Users { get; }
        IRoleRepository UserRoles { get; }
        IAircraftTypeRepository AircraftTypes { get; }
        IAircraftRepository Aircrafts { get; }
        ISightingRepository Sightings { get; }
    }
}
