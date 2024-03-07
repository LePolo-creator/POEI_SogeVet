using Microsoft.CodeAnalysis.CSharp;
using SogeVet.Server.Models;

namespace SogeVet.Server.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string Address { get; set; }

        public required string Status { get; set; }   // string parmi une liste définie

        public List<OrderItem> OrderItems { get; set;}
        public int UserId { get; set; }

        public OrderDto ConvertToDto()
        {
           var orderItemsDto = new List<OrderItemDto>();
           foreach (var item in this.OrderItems) { orderItemsDto.Add(item.ConvertToDto()); };
           return new OrderDto() { Id = this.Id, Address = this.Address, Status = this.Status, OrderItems = orderItemsDto, UserId = this.UserId };
        }
    }
}
