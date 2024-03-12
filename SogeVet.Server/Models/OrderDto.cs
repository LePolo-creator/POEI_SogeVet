using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public string Status { get; set; }   // string parmi une liste définie

        public List<OrderItemDto>? OrderItems { get; set; }  // voir si on garde vraiment orderitems ou bien on les tranforme en string
        public int UserId { get; set; } 

        public Order ConvertToOrder()
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in this.OrderItems) { orderItems.Add(item.ConvertToOrderItem()); };
            return new Order() { Address = this.Address, Status = this.Status, OrderItems = orderItems, UserId = this.UserId  }; // Id généré par la DB
        }
    }

   
}
