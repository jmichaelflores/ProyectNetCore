using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BL;
using DAL;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsBL productsBL;
        
        public ProductsController()
        {
            productsBL = new ProductsBL();
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return productsBL.findAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productsBL.findById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.id_product)
            {
                return BadRequest();
            }

            try
            {
                productsBL.Update(product);

            }
            catch (DbUpdateConcurrencyException)
            {
                
                return NotFound();

            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productsBL.Save(product);

            return CreatedAtAction("GetProduct", new { id = product.id_product }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productsBL.findById(id);
            if (product == null)
            {
                return NotFound();
            }

            productsBL.Delete(product);

            return Ok(product);
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.id_product == id);
        //}
    }
}