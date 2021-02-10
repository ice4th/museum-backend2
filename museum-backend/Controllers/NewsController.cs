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
    public class NewsController : ControllerBase
    {
        private readonly NewsService _newsService;

        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("visitor")]
        public ActionResult<List<News>> GetFotVisitor()
        {
            return _newsService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<News> Get(string id)
        {
            return _newsService.Get(id);
        }

    }
}
