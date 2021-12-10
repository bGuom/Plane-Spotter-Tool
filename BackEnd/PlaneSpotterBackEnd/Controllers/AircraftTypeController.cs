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
    public class AircraftTypeController : BaseController
    {
        public AircraftTypeController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) : base(dbContext, autoMapper, dataWrapper)
        {

        }

        // GET api/AircraftType
        // Get all registered aircraft types
        [HttpGet]
        public ActionResult<IEnumerable<AircraftTypeResponse>> Get()
        {
            List<AircraftTypeResponse> aircraftTypesResponse = new List<AircraftTypeResponse>();
            foreach (var aircraftType in dataWrapper.AircraftTypes.GetAll())
            {
                aircraftTypesResponse.Add(autoMapper.Map<AircraftTypeResponse>(aircraftType));
            }
            return Ok(aircraftTypesResponse);
        }

        // POST api/AircraftType
        // Create new aircraft type
        [HttpPost]
        public ActionResult<AircraftTypeResponse> Post([FromBody] AircraftTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = 400, result = "Input are incorrect" });
            }
            else
            {
                //We need to check whether type is already registered
                var existingAircraftType = dataWrapper.AircraftTypes.FindAll().Where(type => type.Make.Equals(request.Make) && type.Model.Equals(request.Model)).FirstOrDefault();
                if (existingAircraftType != null)
                {
                    return BadRequest(new { status = 400, result = "Already exists" });
                }

                //Otherwise we can create new aircraft type entry
                AircraftType aircraftType = autoMapper.Map<AircraftType>(request);
                dataWrapper.AircraftTypes.AddType(aircraftType);

                return Created("response", new { status = 201, result = autoMapper.Map<AircraftTypeResponse>(aircraftType) });
            }
        }
    }
}
