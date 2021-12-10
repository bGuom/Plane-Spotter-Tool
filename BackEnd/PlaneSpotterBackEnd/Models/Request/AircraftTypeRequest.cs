using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Request
{
    /*
     * Aircraft Type binding model to create AircraftType entity
     */
    public class AircraftTypeRequest
    {

        [Required]
        [StringLength(128)]
        public string Make { get; set; }

        [Required]
        [StringLength(128)]
        public string Model { get; set; }

    }
}
