using System;
using System.Collections.Generic;
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

    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;
        private readonly TaxonomyService _taxonomyService;

        public AnimalController(AnimalService animalService, TaxonomyService taxonomyService)
        {
            _animalService = animalService;
            _taxonomyService = taxonomyService;
        }


        [HttpGet("visitor")]
        public ActionResult<List<Animal>> GetForVisitor()
        {
            return _animalService.Get();
        }



        [HttpGet("{id:length(24)}")]

        public ActionResult<AnimalDetail> Get(string id)
        {
            var animal = _animalService.Get(id);
            var taxonomyId = animal.TaxonomyId;
            var Taxonomy = _taxonomyService.Get(taxonomyId);

            var animalDetail = new AnimalDetail
            {
                Id = animal.Id,
                ThaiName = animal.ThaiName,
                CommoneName = animal.CommoneName,
                ScientificName = animal.ScientificName,
                Description = animal.Description,
                TaxonomyId = Taxonomy,
                BoneImgPath = animal.BoneImgPath,
                ImgPath = animal.ImgPath,
               

            };
            return animalDetail;
        }
        [HttpPut("upload-bone")]
        public ActionResult ReceiveFile([FromForm] IFormFile file)
        {
            return Ok("success");
        }







    }
}
