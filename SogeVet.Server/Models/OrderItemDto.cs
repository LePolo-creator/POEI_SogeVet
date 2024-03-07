using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        public int OrderId { get; set; }   

        // Transformer le productId plutôt en "nom du produit" ? ou  garder le ProductId et faire des find pour récupérer son nom et son image par ex?
        public int ProductId { get; set; }  
        
        public OrderItem ConvertToOrderItem() { 
            return new OrderItem { Quantity = this.Quantity, UnitPrice = this.UnitPrice, OrderId = this.OrderId, ProductId = this.ProductId }; // Id généré par la DB
        }
    }
}

