using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
                CommonName = animal.CommonName,
                ScientificName = animal.ScientificName,
                Description = animal.Description,
                TaxonomyId = Taxonomy,
                BoneImgPath = animal.BoneImgPath,
                ImgPath = animal.ImgPath,
               
            };
            return animalDetail;
        }


         //insert
        [HttpPost()]
        public ActionResult<Animal> ReceiveFile([FromForm] AnimalInput data)
        {
            var newTaxonomy = new Taxonomy()
            {
                Kingdom = data.Kingdom,
                Phylum = data.Phylum,
                SubPhylum = data.SubPhylum,
                InfraPhylum = data.InfraPhylum,
                Class = data.Class,
                SubClass = data.SubClass,
                InfraClass = data.InfraClass,
                Order = data.Order,
                SubOrder = data.SubOrder,
                InfraOrder = data.InfraOrder,
                Family = data.Family,
                SubFamily = data.SubFamily,
                InfraFamily = data.InfraFamily,
                Genus = data.Genus,
                SubGenus = data.SubGenus,
                InfraGenus = data.InfraGenus,
                Species = data.Species,
                SubSpecies = data.SubSpecies,
                InfraSpecies = data.InfraSpecies,

            };
            _taxonomyService.Create(newTaxonomy);         

            var newAnimal = new Animal()
            {
                TaxonomyId = newTaxonomy.Id,
                ThaiName = data.ThaiName,
                CommonName = data.CommonName,
                ScientificName = data.ScientificName,
                Description = data.Description,
                BoneImgPath = data.BoneImgPath,
                ImgPath = data.ImgPath,
            };
            _animalService.Create(newAnimal);

            return Ok(200);
        }

        //update
        [HttpPut("upload-bone")]
        public IActionResult Update([FromForm] Animal animaldata)
        {
            //string Img = _imageService.SaveImg(newsIn.imgPath);
            var newAnimal = new Animal()
            {
                ThaiName = animaldata.ThaiName,
                CommonName = animaldata.CommonName,
                ScientificName = animaldata.ScientificName,
                Description = animaldata.Description,
                BoneImgPath = animaldata.BoneImgPath,
                ImgPath = animaldata.ImgPath,
            };

            _animalService.Update(animaldata.Id, animaldata);


            return Ok("success");
        }

        //delete
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Animal animal;
            {
                animal = _animalService.Get(id);
            }
            _animalService.Remove(animal);

            return NoContent();

        }




    }
}
