using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using museum_backend.Models;
using museum_backend.Services;

namespace museum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly ImageService _imageService;

        public ImageController( ImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet("{path}")]
        public IActionResult Get(string path)
        {
           
            var image = System.IO.File.OpenRead("C:\\Users\\ice\\Source\\Repos\\ice4th\\museum-backend2\\museum-backend\\uploads\\%path%".Replace("%path%", path)); ;
          
            
            return File(image, "image/jpeg");
        }

        [HttpPost]
        public ActionResult<List<String>> Post([FromForm] ImageFormData data)
        {
            var filepath = new List<string>();
            foreach (IFormFile file in HttpContext.Request.Form.Files)
            {
                String filename = this._imageService.SaveImg(file);

                filepath.Add(filename);
            }

            return filepath;
        }
    }
}
