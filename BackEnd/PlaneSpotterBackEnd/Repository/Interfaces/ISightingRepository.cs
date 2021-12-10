using PlaneSpotterBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public interface ISightingRepository
    {
        Sighting GetById(Guid id);
        IEnumerable<Sighting> GetAll();
        Sighting Add(Sighting sighting);
        Task<Sighting> Update(Sighting sighting);
        Task<Sighting> Delete (Sighting sighting);


    }
}
