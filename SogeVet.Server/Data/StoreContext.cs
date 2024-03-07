using Microsoft.EntityFrameworkCore;
using SogeVet.Server.Entities;
using System.Net;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new User[]
            {
                new User{ Id = 1, FirstName= "Admin1", LastName= "Admin1L", Email= "MailAdmin1" , Password= "PasswordAdmin1", Address= "addressadmin1", IsAdmin= true },
                new User{ Id = 2, FirstName= "Admin2", LastName= "Admin2L", Email= "MailAdmin2" , Password= "PasswordAdmin2", Address= "addressadmin2", IsAdmin= true },
                new User{ Id = 3, FirstName= "User1", LastName= "User1L", Email= "MailUser1" , Password= "PasswordUser1", Address= "addressUser1", IsAdmin= false },
                new User{ Id = 4, FirstName= "User2", LastName= "User2L", Email= "MailUser2" , Password= "PasswordUser2", Address= "addressUser2", IsAdmin= false },
                new User{ Id = 5, FirstName= "User3", LastName= "User3L", Email= "MailUser3" , Password= "PasswordUser3", Address= "addressUser3", IsAdmin= false },

            };
            modelBuilder.Entity<User>().HasData(users);
            var categories = new Category[]
            {
                new Category{ Id = 1,Name = "Homme"},
                new Category{ Id = 2,Name = "Femme"},
                new Category{ Id = 3,Name = "Enfant"},

            };
            modelBuilder.Entity<Category>().HasData(categories);
            var products = new Product[]
            {
                new Product{ Id = 1,Name = "Produit 1" ,Description = "Description du produit 1" , Size = 30 ,UnitPrice = 20.5f , Color = "Blanc", Images = new List<string>{"URL1.1","URL1.2","URL1.3"},Quantity = 10, CategoryId = 1},
                new Product{ Id = 2,Name = "Produit 2" ,Description = "Description du produit 2" , Size = 41 ,UnitPrice = 19.58f , Color = "Noir", Images = new List<string>{"URL2.1","URL2.2","URL2.3"},Quantity = 12, CategoryId = 2},
                new Product{ Id = 3,Name = "Produit 3" ,Description = "Description du produit 3" , Size = 52 ,UnitPrice = 10.2f , Color = "Rouge", Images = new List<string>{"URL3.1","URL3.2","URL3.3"},Quantity = 40, CategoryId = 3},
                new Product{ Id = 4,Name = "Produit 4" ,Description = "Description du produit 4" , Size = 32 ,UnitPrice = 40.5f , Color = "Rouge", Images = new List<string>{"URL4.1","URL4.2","URL4.3"},Quantity = 60, CategoryId = 3},
                new Product{ Id = 5,Name = "Produit 5" ,Description = "Description du produit 5" , Size = 36 ,UnitPrice = 1.58f , Color = "Vert", Images = new List<string>{"URL5.1","URL5.2","URL5.3"},Quantity = 100, CategoryId = 2},
                new Product{ Id = 6,Name = "Produit 6" ,Description = "Description du produit 6" , Size = 38 ,UnitPrice = 3.22f , Color = "Bleu", Images = new List<string>{"URL6.1","URL6.2","URL6.3"},Quantity = 2, CategoryId = 1},
                new Product{ Id = 7,Name = "Produit 7" ,Description = "Description du produit 7" , Size = 20 ,UnitPrice = 3.5f , Color = "Violet", Images = new List<string>{"URL7.1","URL7.2","URL7.3"},Quantity = 12, CategoryId = 2},
                new Product{ Id = 8,Name = "Produit 8" ,Description = "Description du produit 8" , Size = 27 ,UnitPrice = 10.58f , Color = "Vert", Images = new List<string>{"URL8.1","URL8.2","URL8.3"},Quantity = 13, CategoryId = 3},
                new Product{ Id = 9,Name = "Produit 9" ,Description = "Description du produit 9" , Size = 25 ,UnitPrice = 6.2f , Color = "Marron", Images = new List<string>{"URL9.1","URL9.2","URL9.3"},Quantity = 24, CategoryId = 1},
                new Product{ Id = 10,Name = "Produit 10" ,Description = "Description du produit 10" , Size = 8 ,UnitPrice = 79.99f , Color = "Turquoise", Images = new List<string>{"URL10.1","URL10.2","URL10.3"},Quantity = 52, CategoryId = 3},
                new Product{ Id = 11,Name = "Produit 11" ,Description = "Description du produit 11" , Size = 10 ,UnitPrice = 19.58f , Color = "Vert", Images = new List<string>{"URL11.1","URL11.2","URL11.3"},Quantity = 62, CategoryId = 1},
                new Product{ Id = 12,Name = "Produit 12" ,Description = "Description du produit 12" , Size = 30 ,UnitPrice = 3.22f , Color = "Noir", Images = new List<string>{"URL12.1","URL12.2","URL12.3"},Quantity = 5, CategoryId = 2},
            };
            modelBuilder.Entity<Product>().HasData(products);
            var orders = new Order[]
            {
                new Order{ Id = 1,Address = "Adress 1",Status = "En attente de traitement",UserId = 3},
                new Order{ Id = 2,Address = "Adress 2",Status = "En attente de traitement",UserId = 4},
                new Order{ Id = 3,Address = "Adress 3",Status = "En attente de traitement",UserId = 5},
                new Order{ Id = 4,Address = "Adress 4",Status = "En attente de traitement",UserId = 3},
                new Order{ Id = 5,Address = "Adress 5",Status = "En attente de traitement",UserId = 3}
            };
            modelBuilder.Entity<Order>().HasData(orders);
            var orderitems = new OrderItem[]
            {
                new OrderItem{ Id = 1,Quantity = 2,UnitPrice = 20f,OrderId = 1,ProductId = 7},
                new OrderItem{ Id = 2,Quantity = 3,UnitPrice = 25.50f,OrderId = 2,ProductId = 4},
                new OrderItem{ Id = 3,Quantity = 4,UnitPrice = 26f,OrderId = 3,ProductId = 3},
                new OrderItem{ Id = 4,Quantity = 10,UnitPrice = 5.99f,OrderId = 1,ProductId = 2},
                new OrderItem{ Id = 5,Quantity = 1,UnitPrice = 80f,OrderId = 2,ProductId = 1},
                new OrderItem{ Id = 6,Quantity = 2,UnitPrice = 5f,OrderId = 1,ProductId = 10},
                new OrderItem{ Id = 7,Quantity = 3,UnitPrice = 40f,OrderId = 4,ProductId = 11},
                new OrderItem{ Id = 8,Quantity = 2,UnitPrice = 15.50f,OrderId = 5,ProductId = 12}
            };
            modelBuilder.Entity<OrderItem>().HasData(orderitems);



        }


    }
}
