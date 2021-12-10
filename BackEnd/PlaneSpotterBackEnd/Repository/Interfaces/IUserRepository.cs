using PlaneSpotterBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);

    }
}
