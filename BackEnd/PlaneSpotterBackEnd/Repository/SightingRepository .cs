using Microsoft.EntityFrameworkCore;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public class SightingRepository : ISightingRepository
    {
        private readonly DatabaseContext dbContext;
        public SightingRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Sighting Add(Sighting sighting)
        {
            dbContext.Sightings.Add(sighting);
            dbContext.SaveChanges();
            return sighting;
        }

        public async Task<Sighting> Delete(Sighting sighting)
        {
            sighting.IsDeleted = true;
            dbContext.Entry(sighting).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return sighting;
        }

        public IQueryable<Sighting> FindAll()
        {
            return dbContext.Sightings
                .Include(sighting => sighting.Aircraft)
                .ThenInclude(aircraft => aircraft.AircraftType)
                .Where(sighting => !sighting.IsDeleted);
        }

        public IEnumerable<Sighting> GetAll()
        {
            return dbContext.Sightings
                .Include(sighting => sighting.Spotter)
                .Include(sighting => sighting.Aircraft)
                .ThenInclude(aircraft => aircraft.AircraftType)
                .Where(sighting => !sighting.IsDeleted)
                .ToList();
        }

        public Sighting GetById(Guid id)
        {
            return dbContext.Sightings
                .Include(sighting => sighting.Spotter)
                .Include(sighting => sighting.Aircraft)
                .ThenInclude(aircraft => aircraft.AircraftType)
                .Where(sighting => !sighting.IsDeleted && sighting.SightingId.Equals(id))
                .FirstOrDefault();
        }

        public async Task<Sighting> Update(Sighting sighting)
        {
            dbContext.Entry(sighting).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return sighting;
        }
    }
}
