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
    public class OrderItemsController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrderItemsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public ActionResult<IEnumerable<OrderItemDto>> GetOrderItems()
        {
            var orderItems = _context.OrderItems;
            var orderItemsDto = new List<OrderItemDto>();
            foreach (var item in orderItems) { orderItemsDto.Add(item.ConvertToDto()); };
            return orderItemsDto;
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public ActionResult<OrderItemDto> GetOrderItem(int id)
        {
            var orderItem =  _context.OrderItems.Find(id);

            if (orderItem == null)
            {
                return NotFound();
            }
            var orderItemDto = orderItem.ConvertToDto();

            return orderItemDto;
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public ActionResult<OrderItemDto> PutOrderItem(int id, OrderItemDto orderItemDto)
        {
            if (id != orderItemDto.Id)
            {
                return BadRequest();
            }
            var item = _context.OrderItems.Find(id);
            // un user ne peut que changer la quantité au panier. Est-ce qu'une ligne du panier = orderitem?? à voir
            item.Quantity = orderItemDto.Quantity;
            _context.SaveChanges();

            return GetOrderItem(id);
        }

        // POST: api/OrderItems
        [HttpPost]
        public ActionResult<OrderItemDto> PostOrderItem(OrderItemDto orderItemDto)
        {
            var orderItem = orderItemDto.ConvertToOrderItem();
            _context.OrderItems.Add(orderItem);
            var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == orderItem.ProductId);
            productToUpdate.Quantity -= orderItem.Quantity;

            _context.SaveChanges();
            orderItemDto.Id = orderItem.Id;

            return orderItemDto;
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(int id)
        {
            var orderItem =  _context.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
           _context.SaveChanges();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
