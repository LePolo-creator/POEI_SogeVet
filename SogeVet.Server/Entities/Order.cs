namespace SogeVet.Server.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string Address { get; set; }

        public required string Status { get; set; }   // string parmi une liste définie

        public List<OrderItem> OrderItems { get; set;}
        public int UserId { get; set; }
    }
}
