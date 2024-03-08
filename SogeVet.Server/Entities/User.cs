using SogeVet.Server.Models;

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


        public UserDto ConvertToDto()
        {
            return new UserDto() { Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, Email = this.Email, Password = this.Password,Address = this.Address,IsAdmin = this.IsAdmin };
        }

   

    }
}
