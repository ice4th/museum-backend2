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
    public class DonerController : ControllerBase
    {
        private readonly DonerService _donerService;

        public DonerController(DonerService donerService)
        {
            _donerService = donerService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<Doner>> GetFotVisitor()
        {
            return _donerService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Doner> Get(string id)
        {
            return _donerService.Get(id);
        }
    }
}
