namespace SogeVet.Server.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Address { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;


        public List<Order>? Orders { get; set; }

    }
}
