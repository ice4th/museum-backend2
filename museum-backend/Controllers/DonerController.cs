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
        public ActionResult<List<Doner>> GetForVisitor()
        {
            return _donerService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Doner> Get(string id)
        {
            return _donerService.Get(id);
        }

        //post
        [HttpPost()]
        public ActionResult<Doner> ReceiveFile([FromForm] DonerInput data)
        {
            var newDoner = new Doner()
            {
                Name = data.Name,
                LastName = data.LastName,
                ImgPath = data.ImgPath,
                PayDate = data.PayDate,
                Donation = data.Donation
            };

            _donerService.Create(newDoner);
            return Ok(200);

        }


        //update
        [HttpPut()]

        public IActionResult Update([FromForm] Doner donerIn)
        {

            var newDoner = new Doner()
            {
                Name = donerIn.Name,
                LastName = donerIn.LastName,
                ImgPath = donerIn.ImgPath,
                PayDate = donerIn.PayDate,
                Donation = donerIn.Donation,
            };

            _donerService.Update(donerIn.Id, donerIn);

            return NoContent();
        }



        //[HttpGet("test/{id:length(24)}")]


        //public IActionResult UpdateDoner(string id)
        //{
        //    return NoContent();
        //}
        //{
        //    Doner doner;
        //    {
        //        doner = _donerService.Get(id);

        //    }
        //    donerIn.Id = doner.Id;

        //    _donerService.Update(id, donerIn);

        //    return NoContent();
        //}


        //delete
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Doner doner;
            {
                doner = _donerService.Get(id);
            }
            _donerService.Remove(doner);

            return NoContent();

        }


    }
}
