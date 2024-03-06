using Microsoft.EntityFrameworkCore;
using SogeVet.Server.Models;

namespace SogeVet.Server.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Size { get; set; }   // string parmi une liste définie
        public float UnitPrice { get; set; }
        public string Color {  get; set; } = "Blanc";   // string parmi une liste définie
        public List<string> Images { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public int CategoryId { get; set; }//ajouter un tableau de product dans la class category


       
        public ProductDto ConvertToDto( String categoryName)
        {
            var productDto = new ProductDto()
            {
                Id = this.Id,
                CategoryName = categoryName,
                Name = this.Name,
                Description = this.Description,
                Color = this.Color,
                Images = this.Images,
                Quantity = this.Quantity,
                Size = this.Size,
                UnitPrice = this.UnitPrice
            };
            return productDto;
        }

    }
}
