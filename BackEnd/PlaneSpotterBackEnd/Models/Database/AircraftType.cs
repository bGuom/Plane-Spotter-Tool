using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
     * Aircraft Type based on Make and Model 
     */
    public class AircraftType : BaseEntity
    {
        public AircraftType()
        {
            AircraftTypeId = new Guid();
        }

        [Key]
        public Guid AircraftTypeId { get; set; }

        [Required]
        [StringLength(128)]
        public string Make { get; set; }

        [Required]
        [StringLength(128)]
        public string Model { get; set; }

        public ICollection<Aircraft> Aircrafts { get; set; }

    }
}
