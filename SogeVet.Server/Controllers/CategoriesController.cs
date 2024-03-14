using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using SogeVet.Server.Data;
using SogeVet.Server.Entities;
using SogeVet.Server.Models;
using SogeVet.Server.Controllers;
using Microsoft.AspNetCore.Authorization;

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
            var categories = _context.Categories.Include(c => c.Products);
            List<CategoryDto> categoriesDto = new List<CategoryDto>() ;
            foreach (var category in categories) {
                // Get products in productDto format
                var productsDto = new List<ProductDto>();
                foreach (var product in category.Products) {
                    var productDto = product.ConvertToDto(category.Name);
                    productsDto.Add(productDto);
                }

                categoriesDto.Add(new CategoryDto { Id = category.Id, Name = category.Name, Products = productsDto });
                
                }
            return  Ok(categoriesDto);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public  ActionResult<CategoryDto> GetCategory(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id).Include(c => c.Products).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            var productsDto = new List<ProductDto>();
            foreach (var product in category.Products)
            {
                var productDto = product.ConvertToDto(category.Name);
                productsDto.Add(productDto);
            }

            return Ok(new CategoryDto { Id = category.Id, Name = category.Name, Products = productsDto });
        }

        // PUT: api/Categories/5
        [Authorize]

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

            return GetCategory(id);
        }

        // POST: api/Categories
        [Authorize]

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
        [Authorize]

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
