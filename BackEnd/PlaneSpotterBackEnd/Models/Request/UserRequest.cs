using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterBackEnd.Models.Request
{
    /*
    User Binding model to create new User entity
    */
    public class UserRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

    }
}
