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
        public ActionResult<List<Organ>> GetForVisitor()
        {
            return _organService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Organ> Get(string id)
        {
            return _organService.Get(id);
        }

        //insert
        [HttpPost()]
        public ActionResult<String> ReceiveFile([FromForm] OrganInput data)
        {
            var status = "";
            var result = _organService.Overlap(data.NameTh);
            if (result == null)
            {
                status = "Upload Success";
                var newOrgan = new Organ()
                {
                    NameTh = data.NameTh,
                    NameEng = data.NameEng,
                    Description = data.Description,
                    ImgPath = data.ImgPath,
                };
                _organService.Create(newOrgan);
            }
            else
            {
                status = "name already exists!";

            }

            return status;
        }


        //update
        [HttpPut("upload-organ")]
        public IActionResult Update([FromForm] Organ data)
        {
            var newOrgan = new Organ()
            {
                NameTh = data.NameTh,
                NameEng = data.NameEng,
                Description = data.Description,
                ImgPath = data.ImgPath,
            };

            _organService.Update(data.Id, data);

            return Ok("success");
        }

        //delete
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Organ organ;
            {
                organ = _organService.Get(id);
            }
            _organService.Remove(organ);

            return NoContent();

        }
    }
}
