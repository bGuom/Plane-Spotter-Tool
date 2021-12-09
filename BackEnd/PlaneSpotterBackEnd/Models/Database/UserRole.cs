using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Database
{
    /*
    User role with access level which will be assigned to User objects. 
    Access level is used to define the authority of a role.
    Higer access level value means more autority.
    */
    public class UserRole : BaseEntity
    {

        public UserRole() {
            RoleId = new Guid();
        }

        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Code { get; set; }

        [Required]
        public int AccessLevel { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
