using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using museum_backend.Models;
using museum_backend.Services;

namespace museum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimalTypeController : Controller
    {
        private readonly AnimalTypeService _animalTypeService;

        public AnimalTypeController(AnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<AnimalType>> GetForVisitor()
        {
            return _animalTypeService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<AnimalType> Get(string id)
        {
            return _animalTypeService.Get(id);
        }


    
    }
}
