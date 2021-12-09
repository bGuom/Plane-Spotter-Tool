using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
     * Aircraft which has a Registration an a Type
     */
    public class Aircraft : BaseEntity
    {

        [Key]
        [Required]
        [StringLength(8, MinimumLength = 3)]
        public string RegistrationId { get; set; }

        [Required]
        public virtual AircraftType AircraftType { get; set; }

        public ICollection<Sighting> Sightings { get; set; }


    }
}
