using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext dbContext;
        public RoleRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserRole AddRole(UserRole role)
        {
            UserRole existigRole = dbContext.UserRoles.Where(ur => ur.Code == role.Code).FirstOrDefault();
            if (existigRole == null)
            {
                dbContext.UserRoles.Add(role);
                dbContext.SaveChanges();
                return role;
            }
            else 
            {
                return existigRole;
            }
            
        }

        public UserRole GetRole(string code)
        {
            return dbContext.UserRoles.Where(role => role.Code == code).FirstOrDefault();
        }
    }
}
