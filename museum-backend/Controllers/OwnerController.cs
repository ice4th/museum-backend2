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
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _ownerService;

        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<Owner>> GetForVisitor()
        {
            return _ownerService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Owner> Get(string id)
        {
            return _ownerService.Get(id);
        }
    }
}
