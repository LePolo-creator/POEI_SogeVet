using SogeVet.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SogeVet.Server.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }


        // foreign keys 
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }



        public OrderItemDto ConvertToDto() {  
            return new OrderItemDto { Id = this.Id, Quantity = this.Quantity, UnitPrice = this.UnitPrice, OrderId = this.OrderId, ProductId = this.ProductId }; 
        }
    }
}
