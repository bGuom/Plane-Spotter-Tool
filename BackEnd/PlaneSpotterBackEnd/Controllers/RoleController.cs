using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using PlaneSpotterBackEnd.Models.Request;
using PlaneSpotterBackEnd.Models.Response;
using PlaneSpotterBackEnd.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PlaneSpotterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        public RoleController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) : base(dbContext, autoMapper, dataWrapper)
        {

        }

        //Initiate default roles of the system
        [HttpGet("initiate_roles")]
        public ActionResult Index()
        {
            dataWrapper.UserRoles.AddRole(new UserRole { Name = "Admin", Code ="AD", AccessLevel = 90});
            dataWrapper.UserRoles.AddRole(new UserRole { Name = "Spotter", Code = "SP", AccessLevel = 10 });
            return Ok();
        }
    }
}
