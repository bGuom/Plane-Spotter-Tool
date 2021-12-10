using PlaneSpotterBackEnd.Models.Database;
using System.Collections.Generic;

namespace PlaneSpotterBackEnd.Repository
{
    public interface IAircraftRepository
    {
        Aircraft GetById(string id);
        IEnumerable<Aircraft> GetAll();
        Aircraft Add(Aircraft aircraft);
    }
}
