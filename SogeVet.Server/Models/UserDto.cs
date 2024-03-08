using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }

        // RAJOUTER LES ORDERS
        public User ConvertToUser()
        {
            return new User() { FirstName = this.FirstName, LastName = this.LastName, Email = this.Email, Password = this.Password,Address = this.Address,IsAdmin = this.IsAdmin }; // Id généré par la DB
        }
    }

}
