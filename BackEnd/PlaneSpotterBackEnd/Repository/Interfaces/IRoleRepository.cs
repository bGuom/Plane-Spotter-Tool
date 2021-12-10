using PlaneSpotterBackEnd.Models.Database;
using System;

namespace PlaneSpotterBackEnd.Repository
{
    public interface IRoleRepository
    {
        UserRole GetRole(String code);
        UserRole AddRole(UserRole role);

    }
}
