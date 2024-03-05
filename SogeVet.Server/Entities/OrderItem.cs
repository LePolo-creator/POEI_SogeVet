using System.ComponentModel.DataAnnotations.Schema;

namespace SogeVet.Server.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }


        // foreign keys 
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
