using SogeVet.Server.Entities;

namespace SogeVet.Server.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Size { get; set; }
        public float UnitPrice { get; set; }
        public string Color { get; set; } = "Blanc";
        public List<string> Images { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public string CategoryName { get; set; } //a faire : ajouter le nom depuis l'id 

        public Product ConvertToProduct(int categoryId)
        {

            return new Product() { Name = this.Name, Description = this.Description,Size = this.Size,UnitPrice = this.UnitPrice,Color=this.Color,Images = this.Images,Quantity = this.Quantity,CategoryId = categoryId };//ID genere par la DB

        }

    }
}
