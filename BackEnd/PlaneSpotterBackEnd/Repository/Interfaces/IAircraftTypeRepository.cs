using PlaneSpotterBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSpotterBackEnd.Repository
{
    public interface IAircraftTypeRepository
    {
        AircraftType GetById(Guid id);
        IEnumerable<AircraftType> GetAll();
        AircraftType AddType(AircraftType type);
        IQueryable<AircraftType> FindAll();

    }
}
