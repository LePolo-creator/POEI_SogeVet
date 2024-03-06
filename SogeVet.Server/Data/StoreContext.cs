using Microsoft.EntityFrameworkCore;
using SogeVet.Server.Entities;

namespace SogeVet.Server.Data
{
    public class StoreContext : DbContext
    {

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = SogeVetDB");
        }
       
    
    }
}
