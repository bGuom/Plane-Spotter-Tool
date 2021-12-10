using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBackEnd.Models.Request;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlaneSpotterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly static string ROOT_URL = "http://localhost:13946/api/";

        public ImageController (IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{type}/{file}")]
        public async Task<IActionResult> GetFile(string type, string file)
        {
            string file_path = Path.Combine(hostingEnvironment.WebRootPath, "images/" + type + "/" + file);
            var imageFile = System.IO.File.OpenRead(file_path);
            return await Task.Run(() => File(imageFile, "image/jpeg"));
        }

        // POST /api/image/upload/type
        // Should have folder named with the given type 
        [HttpPost("upload/{type}")]
        public async Task<IActionResult> PostImage([FromForm] ImageUploadRequest imageUpload, string type)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images/" + type);
            bool exists = System.IO.Directory.Exists(filePath);
            if (!exists) { System.IO.Directory.CreateDirectory(filePath); }
            string fileName = Guid.NewGuid().ToString() + "_" + imageUpload.File.FileName;
            string filepath = Path.Combine(filePath, fileName);
            using (var stream = System.IO.File.Create(filepath))
            {
                await imageUpload.File.CopyToAsync(stream);
            }

            //ROOT_URL + Controller name = image
            string imageurl = ROOT_URL + "image/" + type + "/" + fileName;
            return Ok(imageurl);

        }


    }
}
