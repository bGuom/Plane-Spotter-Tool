using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using PlaneSpotterBackEnd.Models.Request;
using PlaneSpotterBackEnd.Models.Response;
using PlaneSpotterBackEnd.Repository;
using System.Collections.Generic;

namespace PlaneSpotterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : BaseController
    {
        public AircraftController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) : base(dbContext, autoMapper, dataWrapper)
        {

        }

        // GET api/Aircraft
        // Get all registered aircrafts
        [HttpGet]
        public ActionResult<IEnumerable<AircraftResponse>> Get()
        {
            List<AircraftResponse> aircraftResponse = new List<AircraftResponse>();
            foreach (var aircraft in dataWrapper.Aircrafts.GetAll())
            {
                aircraftResponse.Add(autoMapper.Map<AircraftResponse>(aircraft));
            }
            return Ok(aircraftResponse);
        }

        // POST api/Aircraft
        // Create new aircraft
        [HttpPost]
        public ActionResult<AircraftResponse> Post([FromBody] AircraftRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = 400, result = "Input are incorrect" });
            }
            else
            {
                //Check if there is a aircraft type for the provided id,
                //If Aircraft Type is missing we can not save
                var aircraftType = dataWrapper.AircraftTypes.GetById(request.AircraftTypeId);
                if (aircraftType == null) 
                {
                    return NotFound(new { status = 404, result = "Aircraft Type Not Found" });
                }

                //We need to check whether plane is already registered
                var existingAircraft = dataWrapper.Aircrafts.GetById(request.RegistrationId);
                if (existingAircraft != null)
                {
                    return BadRequest(new { status = 400, result = "Already exists" });
                }
                
                //Otherwise we can create new aircraft entry
                Aircraft aircraft = autoMapper.Map<Aircraft>(request);
                aircraft.AircraftType = aircraftType;
                dataWrapper.Aircrafts.Add(aircraft);

                return Created("response", new { status = 201, result = autoMapper.Map<AircraftResponse>(aircraft)});
            }
        }
    }
}
