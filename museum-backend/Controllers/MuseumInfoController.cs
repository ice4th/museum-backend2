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
    public class MuseumInfoController : ControllerBase
    {
        private readonly MuseumInfoService _museumInfoService;

        public MuseumInfoController(MuseumInfoService museumInfoService)
        {
            _museumInfoService = museumInfoService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<MuseumInfo>> GetFotVisitor()
        {
            return _museumInfoService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<MuseumInfo> Get(string id)
        {
            return _museumInfoService.Get(id);
        }
    }
}
