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
    public class TaxonomyController : ControllerBase
    {
        private readonly TaxonomyService _taxonomyService;

        public TaxonomyController(TaxonomyService taxonomyService)
        {
            _taxonomyService = taxonomyService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<Taxonomy>> GetFotVisitor()
        {
            return _taxonomyService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Taxonomy> Get(string id)
        {
            return _taxonomyService.Get(id);


        }
    }
}
