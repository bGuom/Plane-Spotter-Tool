using System;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Request
{
    /*
     * Plane sighting binding model to create Sighting entity
     */
    public class SightingRequest
    {
        public Guid SightingId { get; set; }

        [Required]
        public string AircraftId { get; set; }

        [Required]
        public Guid SpotterId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Location { get; set; }

        public string Image { get; set; }
    }
}
