using System;

namespace PlaneSpotterBackEnd.Models.Response
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
