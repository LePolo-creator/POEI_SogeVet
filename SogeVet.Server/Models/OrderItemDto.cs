using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }


        
        public int OrderId { get; set; }   // A garder ou pas ?

        // Transformer le productId plutôt en "nom du produit" ? ou  garder le ProductId et faire des find pour récupérer son nom et son image par ex?
        public int ProductId { get; set; }  
        // public Product Product { get; set; }
    }
}

