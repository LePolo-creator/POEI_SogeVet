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
                new Product{ Id = 1,Name = "Veste Bleu" ,Description = "Veste Bleu costard" , Size = 30 ,UnitPrice = 20.5f , Color = "Bleu", Images = new List<string>{ "https://www.angledelamode.com/public/img/big/IMG9218jpeg_6436b12ec91ee.jpeg", "https://mobile.yoox.com/images/items/49/49867134XU_14_f.jpg?impolicy=crop&width=387&height=490","https://static.fursac.com/data/cache/LandingPage/picture/main/f/f/306.1606245987.jpg"},Quantity = 10, CategoryId = 1},
                new Product{ Id = 2,Name = "Robe Jaune" ,Description = "Robe jaune avec pois" , Size = 41 ,UnitPrice = 19.58f , Color = "Jaune", Images = new List<string>{ "https://www.tendance-retro.fr/cdn/shop/products/robe-jaune-a-pois-style-pin-up-284_1200x1200.jpg?v=1657442970", "https://robe-fleurie.fr/cdn/shop/products/H9158b11ff7f7490d9163393b8e0fdd522_1500x1500.jpg?v=1655929435", "https://www.oksana-mukha.fr/wp-content/uploads/2021/05/robe-de-cocktail-jaune-vif.jpg"},Quantity = 12, CategoryId = 2},
                new Product{ Id = 3,Name = "Short Bleu" ,Description = "Description du produit 3" , Size = 52 ,UnitPrice = 10.2f , Color = "Rouge", Images = new List<string>{"https://www.sao-bio.fr/6260-large_default/short-bebe-coton-bio-rayures-bleues.jpg", "https://www.saisondesabeilles.fr/wp-content/uploads/Saison-des-Abeilles-Vetements-enfants-Habillement-bebe-coton-biologique-garcon-fille-short-bleu-fonce1.jpg"},Quantity = 40, CategoryId = 3},
                new Product{ Id = 4,Name = "t shirt enfant vert" ,Description = "Description du produit 4" , Size = 32 ,UnitPrice = 40.5f , Color = "Vert", Images = new List<string>{ "https://www.tee-shirt-publicitaire-pro.com/images/tee-shirt-publicitaire/large/t-shirt-publicitaire-fotoco-pour-enfant-vert_kelly_2.jpg", "https://www.ekinsport.com/media/catalog/product/cache/173ef9ab000c6667578594f63bf9da15/c/z/cz0909-302_t-shirt-nike-team-club-20-vert-pour-enfant-cz0909-302_01.jpg", "https://www.crafters.fr/images/stories/virtuemart/tt2016/PS_GI5000B_IRISHGREEN.jpg"},Quantity = 60, CategoryId = 3},
                new Product{ Id = 5,Name = "tshirt femme violet" ,Description = "Description du produit 5" , Size = 36 ,UnitPrice = 1.58f , Color = "Violet", Images = new List<string>{ "https://www.basket-sucy.fr/wp-content/uploads/2022/09/des-petit-hauts-tee-shirt-frizon-violet-violet-t-shirts-tops-femme.jpg", "https://www.lagentlefactory.com/img/p/1/1/3/0/8/11308-medium_default.jpg"},Quantity = 100, CategoryId = 2},
                new Product{ Id = 6,Name = "pantalon homme cargo" ,Description = "Description du produit 6" , Size = 38 ,UnitPrice = 3.22f , Color = "Vert", Images = new List<string>{ "https://image1.superdry.com/static/images/optimised/zoom/upload9223368955666328142.jpg", "https://images.asos-media.com/products/selected-homme-pantalon-cargo-vert-fonce/12511990-4?$n_640w$&wid=513&fit=constrain", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCQAO8ogt8GohpJASx9VtsSwr8_HgHFKFPV25Z5TQ3WA&s", "https://www.boutique-militaire.fr/cdn/shop/products/pantalon-cargo-vert-kaki-homme-boutique-militaire_600x600.jpg?v=1650033892"},Quantity = 2, CategoryId = 1},
                new Product{ Id = 7,Name = "pull femme hiver noir" ,Description = "Description du produit 7" , Size = 20 ,UnitPrice = 3.5f , Color = "Noir", Images = new List<string>{ "https://www.cdiscount.com/pdt2/6/4/4/3/700x700/mp135295644/rw/pull-femme-en-tricot-col-v-avec-boutons-manches-lo.jpg", "https://www.cdiscount.com/pdt2/5/0/6/1/700x700/mp128602506/rw/pull-femme-en-tricot-court-col-arrondi-manches-lon.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9Ai1-uVO7dPC98wUI9hKs59CA7q4PHsnZrCEii3nwg&s"},Quantity = 12, CategoryId = 2},
                new Product{ Id = 8,Name = "Veste enfant rayé" ,Description = "Description du produit 8" , Size = 27 ,UnitPrice = 10.58f , Color = "Bleu", Images = new List<string>{"https://lp2.hm.com/hmgoepprod?set=quality%5B79%5D%2Csource%5B%2F30%2F93%2F30930506ba1409bdaf7eeddbeed199f7ac5b1783.jpg%5D%2Corigin%5Bdam%5D%2Ccategory%5Bkids_boys_clothing_jumperssweatshirts_hoodies%5D%2Ctype%5BDESCRIPTIVESTILLLIFE%5D%2Cres%5Bm%5D%2Chmver%5B2%5D&call=url[file:/product/main]", "https://www.brise-lames.com/3452-large_default/gilet-capuche-en-molleton-raye-ecrumarine-enfant.jpg"},Quantity = 13, CategoryId = 3},
                new Product{ Id = 9,Name = "Short de bain rayé homme" ,Description = "Description du produit 9" , Size = 25 ,UnitPrice = 6.2f , Color = "Bleu", Images = new List<string>{"https://www.americanvintage-store.com/dw/image/v2/BGNV_PRD/on/demandware.static/-/Sites-master-catalog/default/dw8bf99e72/images/productPictures/E23/MODU09AE23/MODU09AE23-RAYBLEU-MODEL-4-large.jpg?sw=720&sh=1125", "https://cdn.monsieurtshirt.com/images/87908/product_list/filgood-l-homme-ideal-cocarde-brode.jpg?1627899944000"},Quantity = 24, CategoryId = 1},
                new Product{ Id = 10,Name = "Bavoir bébé" ,Description = "Description du produit 10" , Size = 8 ,UnitPrice = 79.99f , Color = "Jaune", Images = new List<string>{"https://www.petitspinpins.com/1997-large_default/bavoir-bebe-raton-laveur-jaune.jpg", "https://www.ludilabel.fr/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/p/a/packshot-bavoir-trixie-mr-lion-bib.jpg"},Quantity = 52, CategoryId = 3},
                new Product{ Id = 11,Name = "Chaussettes marron" ,Description = "Description du produit 11" , Size = 10 ,UnitPrice = 19.58f , Color = "Marron", Images = new List<string>{"https://cdn1.incorio.com/3034-large_default/chaussettes-fil-decosse-marron.jpg", "https://www.boulevard-dore.fr/44840-large_default/chaussettes-homme-soft-cotton-marron.jpg"},Quantity = 62, CategoryId = 1},
                new Product{ Id = 12,Name = "Collant Femme" ,Description = "Description du produit 12" , Size = 30 ,UnitPrice = 3.22f , Color = "Noir", Images = new List<string>{ "https://www.cdiscount.com/pdt2/9/2/5/1/700x700/mp61405925/rw/collant-femme-hiver-thermiques-collan-double-polai.jpg", "https://www.collantfemme.fr/355-large_default/collant-noir-fantaisie-fleuri-mila.jpg", "https://jambissima.fr/media/cache/w_500/6d/71/3a0b95e82b4318056b84ba521639.jpg"},Quantity = 5, CategoryId = 2},
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
