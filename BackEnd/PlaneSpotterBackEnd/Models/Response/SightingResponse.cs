using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Models.Database
{
    public class SightingResponse
    {
        public Guid SightingId { get; set; }
        public AircraftResponse Aircraft { get; set; }
        public UserResponse Spotter { get; set; }
        public DateTime DateTime { get; set; }
        public string Image { get; set; }
    }
}
