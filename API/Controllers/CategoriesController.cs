using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using BL;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoriesBL categoriesBL;

        public CategoriesController()
        {
            categoriesBL = new CategoriesBL();

        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return categoriesBL.findAll();
        }

        //    GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = categoriesBL.findById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        //    PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.id_category)
            {
                return BadRequest();
            }

            try
            {
                categoriesBL.Update(category);

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return Ok(category);
        }

        //    POST: api/Categories
        //   [HttpPost]
        public  IActionResult PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            categoriesBL.Save(category);

            return CreatedAtAction("GetCategory", new { id = category.id_category }, category);
        }

        //DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = categoriesBL.findById(id);
            if (category == null)
            {
                return NotFound();
            }

            categoriesBL.Delete(category);

            return Ok(category);
        }

    }
}