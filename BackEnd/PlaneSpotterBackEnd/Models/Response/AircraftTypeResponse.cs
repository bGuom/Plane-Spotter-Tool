using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
    Aircraft Type Response Model
    */
    public class AircraftTypeResponse
    {
        public Guid AircraftTypeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
