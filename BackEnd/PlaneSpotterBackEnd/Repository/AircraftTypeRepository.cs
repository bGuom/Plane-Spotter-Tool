using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSpotterBackEnd.Repository
{
    public class AircraftTypeRepository : IAircraftTypeRepository
    {
        private readonly DatabaseContext dbContext;
        public AircraftTypeRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AircraftType AddType(AircraftType type)
        {
            dbContext.AircraftTypes.Add(type);
            dbContext.SaveChanges();
            return type;
        }

        public IQueryable<AircraftType> FindAll()
        {
            return dbContext.AircraftTypes;
        }

        public IEnumerable<AircraftType> GetAll()
        {
            return dbContext.AircraftTypes
                .Where(aircraftType => !aircraftType.IsDeleted)
                .ToList();
        }

        public AircraftType GetById(Guid id)
        {
            return dbContext.AircraftTypes
                .Where(aircraftType => aircraftType.AircraftTypeId.Equals(id) && !aircraftType.IsDeleted)
                .FirstOrDefault();
        }
    }
}
