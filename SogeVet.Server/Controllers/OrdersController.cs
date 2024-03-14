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
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrdersController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _context.Orders.Include(o => o.OrderItems);
            var ordersDto = new List<OrderDto>();
            foreach (var order in orders) {ordersDto.Add(order.ConvertToDto());}
            return ordersDto;
        }

        // GET: api/Orders/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order =  _context.Orders.Where(o => o.Id == id).Include(o => o.OrderItems).FirstOrDefault(); 

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = order.ConvertToDto();
            return orderDto;
        }

        // PUT: api/Orders/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<OrderDto> PutOrder(int id, OrderDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }
            var orderToEdit = _context.Orders.Find(id);

            orderToEdit.Status = orderDto.Status;
            orderToEdit.Address = orderDto.Address; // Conditionner au status
            _context.SaveChanges();
            // Pas de gestion d'erreur?

            return GetOrder(id);   // ou retourner juste Ok(orderDto)
        }

        // POST: api/Orders
        [Authorize]
        [HttpPost]
        public ActionResult<OrderDto> PostOrder(OrderDto orderDto)
        {
            var order = orderDto.ConvertToOrder();
            order.Status = "En cours de traitement";
            _context.Orders.Add(order);
            _context.SaveChanges();
            orderDto.Id = order.Id;
            orderDto.Status = order.Status;

            return orderDto;
        }

        // DELETE: api/Orders/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
