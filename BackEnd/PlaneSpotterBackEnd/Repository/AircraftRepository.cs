using Microsoft.EntityFrameworkCore;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSpotterBackEnd.Repository
{
    public class AircraftRepository : IAircraftRepository
    {
        private readonly DatabaseContext dbContext;
        public AircraftRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Aircraft Add(Aircraft aircraft)
        {
            dbContext.Aircrafts.Add(aircraft);
            dbContext.SaveChanges();
            return aircraft;
        }

        public IEnumerable<Aircraft> GetAll()
        {
            return dbContext.Aircrafts
                .Include(aircraft => aircraft.AircraftType)
                .Where(aircrafts => !aircrafts.IsDeleted)
                .ToList();
        }

        public Aircraft GetById(string id)
        {
            return dbContext.Aircrafts
                .Include(aircraft => aircraft.AircraftType)
                .Where(aircrafts => !aircrafts.IsDeleted && aircrafts.RegistrationId.Equals(id))
                .FirstOrDefault();
        }
    }
}
