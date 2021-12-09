using System;

namespace PlaneSpotterBackEnd.Models.Response
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
