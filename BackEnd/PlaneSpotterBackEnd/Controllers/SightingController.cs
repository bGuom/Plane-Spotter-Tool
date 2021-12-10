using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using PlaneSpotterBackEnd.Models.Request;
using PlaneSpotterBackEnd.Models.Response;
using PlaneSpotterBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingController : BaseController
    {
        public SightingController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) : base(dbContext, autoMapper, dataWrapper)
        {

        }

        // GET api/Sighting
        // Get all recorded sightings
        [HttpGet]
        public ActionResult<IEnumerable<SightingResponse>> Get()
        {
            List<SightingResponse> sighthingResponse = new List<SightingResponse>();
            foreach (var sighting in dataWrapper.Sightings.GetAll())
            {
                sighthingResponse.Add(autoMapper.Map<SightingResponse>(sighting));
            }
            return Ok(sighthingResponse);
        }

        // GET api/Sighting/{id}
        // Get sighting by id
        [HttpGet("{id}")]
        public ActionResult<SightingResponse> GetById(Guid id)
        {
            Sighting sighting = dataWrapper.Sightings.GetById(id);

            if (sighting == null)
            {
                return NotFound(new { status = 404, result = "Record Not Found" });
            }
            return Ok(autoMapper.Map<SightingResponse>(sighting));
        }


        // POST api/Sighting
        // Create new sighting record
        [HttpPost]
        public ActionResult<SightingResponse> Post([FromBody] SightingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = 400, result = "Input are incorrect" });
            }
            else
            {
                //Check if date time is valid
                if (request.DateTime - DateTime.Now > TimeSpan.FromSeconds(1))
                {
                    return BadRequest(new { status = 400, result = "Invalid date time" });
                }

                //Check if there is a aircraft for the provided id,
                //If Aircraft is missing we can not save
                var aircraft = dataWrapper.Aircrafts.GetById(request.AircraftId);
                if (aircraft == null)
                {
                    return NotFound(new { status = 404, result = "Aircraft Not Found" });
                }

                //We need to check whether the user is existing
                var existingSpotter = dataWrapper.Users.GetUser(request.SpotterId);
                if (existingSpotter == null)
                {
                    return NotFound(new { status = 400, result = "Spotter does not exists" });
                }

                //Otherwise we can create new sighting entry
                Sighting sighting = autoMapper.Map<Sighting>(request);
                sighting.Aircraft = aircraft;
                sighting.Spotter = existingSpotter;
                dataWrapper.Sightings.Add(sighting);

                return Created("response", new { status = 201, result = autoMapper.Map<SightingResponse>(sighting) });
            }
        }


        // PUT api/Sighting
        // Update existing sighting record
        [HttpPut]
        public ActionResult<SightingResponse> Put([FromBody] SightingRequest request)
        {
            if (!ModelState.IsValid || request.SightingId == null || request.Equals(""))
            {
                return BadRequest(new { status = 400, result = "Input are incorrect" });
            }
            else
            {
                //Check if date time is valid
                if (request.DateTime - DateTime.Now > TimeSpan.FromSeconds(1)) {
                    return BadRequest(new { status = 400, result = "Invalid date time" });
                }

                //Check if there is a record for the provided id,
                //If Record is missing we can not update
                var sighting = dataWrapper.Sightings.GetById(request.SightingId);
                if (sighting == null)
                {
                    return NotFound(new { status = 404, result = "Record Not Found" });
                }

                //Check if there is a aircraft for the provided id,
                //If Aircraft is missing we can not save
                var aircraft = dataWrapper.Aircrafts.GetById(request.AircraftId);
                if (aircraft == null)
                {
                    return NotFound(new { status = 404, result = "Aircraft Not Found" });
                }

                //We need to check whether the user is existing
                var existingSpotter = dataWrapper.Users.GetUser(request.SpotterId);
                if (existingSpotter == null)
                {
                    return NotFound(new { status = 400, result = "Spotter does not exists" });
                }

                //Otherwise we can create new sighting entry
                Sighting updatedSighting = autoMapper.Map<Sighting>(request);
                updatedSighting.Aircraft = aircraft;
                updatedSighting.Spotter = existingSpotter;
                dataWrapper.Sightings.Update(updatedSighting);

                return Ok(new { status = 200, result = autoMapper.Map<SightingResponse>(updatedSighting) });
            }
        }

        // DELETE api/Sighting/{id}
        // Delete existing sighting record
        [HttpDelete("{id}")]
        public async Task<ActionResult<SightingResponse>> Delete(Guid id)
        {
            //Check if there is a record for the provided id,
            //If Record is missing we can not update
            var sighting = dataWrapper.Sightings.GetById(id);
            if (sighting == null)
            {
                return NotFound(new { status = 404, result = "Record Not Found" });
            }
            var result = await dataWrapper.Sightings.Delete(sighting);
            return Ok(new { status = 200, result = autoMapper.Map<SightingResponse>(result) });
        }
    }
}
