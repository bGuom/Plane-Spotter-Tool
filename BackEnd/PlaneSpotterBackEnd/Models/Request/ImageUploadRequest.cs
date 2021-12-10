using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace PlaneSpotterBackEnd.Models.Request
{
    public class ImageUploadRequest
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
