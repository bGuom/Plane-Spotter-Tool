using System;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
     * Plane sighting records which required information and image url
     */
    public class Sighting : BaseEntity
    {
        public Sighting()
        {
            SightingId = new Guid();
        }

        [Key]
        public Guid SightingId { get; set; }

        [Required]
        public virtual Aircraft Aircraft { get; set; }

        [Required]
        public virtual User Spotter { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public string Image { get; set; }
    }
}
