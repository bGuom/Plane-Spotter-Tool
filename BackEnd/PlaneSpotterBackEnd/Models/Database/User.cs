using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
    User class with User Role
    User is used for authentication and recording of sigtings
    */
    public class User : BaseEntity
    {
        public User()
        {
            UserId = new Guid();
        }

        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public virtual UserRole UserRole { get; set; }
        public ICollection<Sighting> Sightings { get; set; }
    }
}
