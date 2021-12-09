using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Models.Database
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
