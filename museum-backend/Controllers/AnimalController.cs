using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using museum_backend.Models;
using museum_backend.Services;
using Excel = Microsoft.Office.Interop.Excel;

namespace museum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;
        private readonly TaxonomyService _taxonomyService;

        public AnimalController(AnimalService animalService, TaxonomyService taxonomyService)
        {
            _animalService = animalService;
            _taxonomyService = taxonomyService;
        }

        


        [HttpGet("visitor")]
        public ActionResult<List<Animal>> GetForVisitor()
        {
            return _animalService.Get();
        }

        [HttpGet("{id:length(24)}")]

        public ActionResult<AnimalDetail> Get(string id)
        {
            var animal = _animalService.Get(id);
            var taxonomyId = animal.TaxonomyId;
            var Taxonomy = _taxonomyService.Get(taxonomyId);

            var animalDetail = new AnimalDetail
            {
                Id = animal.Id,
                ThaiName = animal.ThaiName,
                CommoneName = animal.CommoneName,
                ScientificName = animal.ScientificName,
                Description = animal.Description,
                TaxonomyId = Taxonomy,
                BoneImgPath = animal.BoneImgPath,
                ImgPath = animal.ImgPath,
               

            };
            return animalDetail;
        }


        [HttpPut("upload-bone")]
        public async Task<ActionResult> ReceiveFile([FromForm] IFormFile file)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file.FileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return Ok("success");
        }





    }
}
