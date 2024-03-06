using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SogeVet.Server.Data;
using SogeVet.Server.Entities;
using SogeVet.Server.Models;

namespace SogeVet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreContext _context;

        public CategoriesController(StoreContext context)
        {
            _context = context;
        }

        /* Only admin users can Create / Put / Delete a category
         * Any API client can Get categories or a category
         * TO DO : Authentication for create / put / delete
        */


        // GET: api/Categories
        [HttpGet]
        public  ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _context.Categories;
            return  Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public  ActionResult<CategoryDto> GetCategory(int id)
        {
            var category =  _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult<CategoryDto> PutCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }

            var categoryToEdit = _context.Categories.Find(id);
            if (categoryToEdit == null) {
                return NotFound();
            }
            categoryToEdit.Name = categoryDto.Name;

            _context.SaveChanges();

            return Ok(categoryToEdit);
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult<CategoryDto> PostCategory(CategoryDto categoryDto)
        {
            var categoryToAdd = new Category { Name = categoryDto.Name  };
            _context.Categories.Add(categoryToAdd);
            _context.SaveChanges();

            categoryDto.Id = categoryToAdd.Id;

            return Ok(categoryDto);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok("Category was successfully deleted");
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
