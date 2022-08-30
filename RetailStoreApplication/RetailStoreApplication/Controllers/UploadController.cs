using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreApplication.Context;
using RetailStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetailStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private RetailContext _retailContext;

        public UploadController(RetailContext retailContext)
        {
            _retailContext = retailContext;
        }

        // POST api/<UploadController>
        [HttpPost("PostFile")]
        public IActionResult PostFile(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(fileStream))
            {
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    string[] csvfilerecord = record.Split('\n');
                    foreach (var row in csvfilerecord)
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            var cells = row.Split(',');
                            var product = new Product
                            {
                                StoreId = Convert.ToInt32(cells[0]),
                                Sku = cells[1],
                                ProductName = cells[2],
                                Price = Convert.ToDecimal(cells[3]),
                                Date = cells[4]
                            };
                            _retailContext.Products.Add(product);
                        }

                    }

                }

            }
            _retailContext.SaveChanges();
            return Ok();
        }        

    }
}
