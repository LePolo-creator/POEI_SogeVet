using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _context.Products.Include(p=>p.Category);
            var productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(product.ConvertToDto(product.Category.Name));
            }
            return Ok(productsDto);

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var product = _context.Products.Include(p => p.Category).Where(p=>p.Id==id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }
            var category = product.Category.Name;

            return Ok(product.ConvertToDto(category));
        }

        [HttpGet("filter/{filter}")]
        public ActionResult<IEnumerable<ProductDto>> GetProductsFilter(string filter)
        {
            var category = _context.Categories.Where(c=>c.Name == filter).FirstOrDefault();
            var products = _context.Products.Include(p => p.Category).Where(p=>p.CategoryId==category.Id);

            if (products == null)
            {
                return NotFound();
            }
            var productsDTO = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDTO.Add(product.ConvertToDto(category.Name));
            }

            return Ok(productsDTO);
        }


        // PUT: api/Products/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<ProductDto> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var productToEdit = _context.Products.Find(id);
            if (productToEdit == null)
            {
                return NotFound();
            }
            var category = _context.Categories.Where(c=>c.Name == productDto.CategoryName).FirstOrDefault();
            productToEdit.CategoryId = category.Id;
            productToEdit.Name = productDto.Name;
            productToEdit.Description = productDto.Description;
            productToEdit.Color = productDto.Color;
            productToEdit.Images = productDto.Images;
            productToEdit.Quantity = productDto.Quantity;
            productToEdit.Size = productDto.Size;
            productToEdit.UnitPrice = productDto.UnitPrice;

            _context.SaveChanges();


            return GetProduct(id);

        }

        // POST: api/Products
        [Authorize]

        [HttpPost]
        public ActionResult<Product> PostProduct(ProductDto productDto)
        {
            int categoryID = _context.Categories.Where(c=>c.Name == productDto.CategoryName).FirstOrDefault().Id;
            var newProduct = productDto.ConvertToProduct(categoryID);
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            productDto.Id = newProduct.Id;
            return Ok(productDto);
        }

        // DELETE: api/Products/5
        [Authorize]

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }

    }
}
