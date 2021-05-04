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
        public ActionResult<List<News>> GetForVisitor()
        {
            return _newsService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<News> Get(string id)

        {
            return _newsService.Get(id);
        }

        //insert
        [HttpPost()]
        public ActionResult<News> ReceiveFile([FromForm] NewsInput data)
        {
            var newNews = new News()
            {
                Title = data.Title,
                Description = data.Description,
                ImgPath = data.ImgPath,
            };
            _newsService.Create(newNews);
        
            return Ok(200);
        }

        //update
        [HttpPut()]
        public IActionResult Update([FromForm] News newsIn)
        {
            var newNews = new News()
            {
                Title = newsIn.Title,
                Description = newsIn.Description,
                ImgPath = newsIn.ImgPath,
            };

            _newsService.Update(newsIn.Id, newsIn);

            return NoContent();
        }

        //delete
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            News news;
            {
                news = _newsService.Get(id);
            }
            _newsService.Remove(news);

            return NoContent();

        }













        /* if (GetClaim(User, ClaimEnum.UserType) == "A")
         {
             news = _newsService.Get(id);
         }
         else
         {
             news = _newsService.Get(id, int.Parse(GetClaim(User, ClaimEnum.DeptNo)));
         }
         if (news == null)
         {
             return NotFound();
         }
         newsIn.Id = news.Id;
         newsIn.DeptNo = int.Parse(GetClaim(User, ClaimEnum.DeptNo));

         _newsService.Insert(id, newsIn);

         return NoContent();
     }*/

        /*
        // update news แก้ยังไม่เสร็จ
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, News newsIn)
        {
            News news;
            if (GetClaim(User, ClaimEnum.UserType) == "A")
            {
                news = _dogService.Get(id);
            }
            else
            {
                news = _newsService.Get(id, int.Parse(GetClaim(User, ClaimEnum.DeptNo)));
            }
            
            if (news == null)
            {
                return NotFound();
            }
            newsIn.Id = news.Id;
            newsIn.DeptNo = int.Parse(GetClaim(User, ClaimEnum.DeptNo));

            _newsService.Update(id, newsIn);

            return NoContent();
        }

        //remove news แก้ยังไม่เสร็จ
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            News news;
            if (GetClaim(User, ClaimEnum.UserType) == "A")
            {
                news = _dogService.Get(id);
            }
            else
            {
                news = _dogService.Get(id, int.Parse(GetClaim(User, ClaimEnum.DeptNo)));
            }

            if (news == null)
            {
                return NotFound();
            }

            _newsService.Remove(news);

            return NoContent();
        }*/
    }
}
