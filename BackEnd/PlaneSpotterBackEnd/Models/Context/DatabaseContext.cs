using Microsoft.EntityFrameworkCore;
using PlaneSpotterBackEnd.Models.Database;

namespace PlaneSpotterBackEnd.Models.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
    }
}
