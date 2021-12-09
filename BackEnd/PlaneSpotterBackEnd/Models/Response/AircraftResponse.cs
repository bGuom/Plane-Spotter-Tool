using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
    Aircraft Response Model
    */
    public class AircraftResponse
    {
        public string RegistrationId { get; set; }
        public AircraftTypeResponse AircraftType { get; set; }
    }
}
