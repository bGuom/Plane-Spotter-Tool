using System;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Request
{
    /*
     * Aircraft binding model to create Aircraft entity
     */
    public class AircraftRequest
    {
        [Required]
        [StringLength(8, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]{1,2}[-][A-Z]{1,5}$", ErrorMessage = "Incorrect Format.")]
        public string RegistrationId { get; set; }

        [Required]
        public Guid AircraftTypeId { get; set; }

    }
}
