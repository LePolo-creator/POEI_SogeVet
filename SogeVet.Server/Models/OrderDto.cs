using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required string Address { get; set; }

        public required string Status { get; set; }   // string parmi une liste définie

        public List<OrderItemDto> OrderItems { get; set; }  // voir si on garde vraiment orderitems ou bien on les tranforme en string
        public int UserId { get; set; } // garder ou pas?
    }
}
