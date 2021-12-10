using PlaneSpotterBackEnd.Models.DatabaseContext;

namespace PlaneSpotterBackEnd.Repository
{
    public class DataRepositoryWrapper : IDataRepositoryWrapper
    {
        private readonly DatabaseContext dbContext;

        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IAircraftTypeRepository aircraftTypeRepository;
        private IAircraftRepository aircraftsRepository;
        private ISightingRepository sightingsRepository;

        public DataRepositoryWrapper(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IUserRepository Users => userRepository ?? (userRepository = new UserRepository(dbContext));
        public IRoleRepository UserRoles => roleRepository ?? (roleRepository = new RoleRepository(dbContext));
        public IAircraftTypeRepository AircraftTypes => aircraftTypeRepository ?? (aircraftTypeRepository = new AircraftTypeRepository(dbContext));
        public IAircraftRepository Aircrafts => aircraftsRepository ?? (aircraftsRepository = new AircraftRepository(dbContext));
        public ISightingRepository Sightings => sightingsRepository ?? (sightingsRepository = new SightingRepository(dbContext));
    }
}
