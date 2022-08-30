using Microsoft.AspNetCore.Mvc;
using RetailStoreApplication.Context;
using RetailStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetailStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private RetailContext _retailContext;

        public ProductController(RetailContext retailContext)
        {
            _retailContext = retailContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _retailContext.Products;
        }

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var product = _retailContext.Products.FirstOrDefault(s => s.ProductId == id);
            if (product != null)
            {
                _retailContext.Entry<Product>(product).CurrentValues.SetValues(value);
                _retailContext.SaveChanges();
            }
        }

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
