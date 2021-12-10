using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext dbContext;
        public UserRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public User AddUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }

        public User GetUser(Guid id)
        {
            return dbContext.Users.Where(user => user.UserId.Equals(id)).FirstOrDefault();
        }
    }
}
