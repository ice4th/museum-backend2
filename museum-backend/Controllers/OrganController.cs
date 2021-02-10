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
    public class OrganController : ControllerBase
    {
        private readonly OrganService _organService;

        public OrganController(OrganService organService)
        {
            _organService = organService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<Organ>> GetFotVisitor()
        {
            return _organService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Organ> Get(string id)
        {
            return _organService.Get(id);


        }
    }
}
