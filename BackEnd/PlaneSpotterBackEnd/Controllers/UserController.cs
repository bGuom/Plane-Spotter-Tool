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
    public class UserController : BaseController
    {
        public UserController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) : base(dbContext, autoMapper, dataWrapper)
        {

        }

        // GET api/User
        // Get all registered users
        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> Get()
        {
            List<UserResponse> userResponse = new List<UserResponse>();
            foreach (var user in dataWrapper.Users.GetAllUsers())
            {
                userResponse.Add(autoMapper.Map<UserResponse>(user));
            }
            return Ok(userResponse);
        }

        // POST api/User
        // Create new user
        [HttpPost]
        public ActionResult<UserResponse> Post([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = 200, result = "Input are incorrect" });
            }
            else
            {
                User user = autoMapper.Map<User>(request);
                user.UserRole = dataWrapper.UserRoles.GetRole("SP");
                dataWrapper.Users.AddUser(user);
                return Created("response", new { status = 201, result = autoMapper.Map<UserResponse>(user) });
            }
        }
    }
}
