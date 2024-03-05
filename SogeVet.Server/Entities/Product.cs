namespace SogeVet.Server.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Size { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Color {  get; set; } = "Blanc";
        public List<string> Images { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public int CategoryId { get; set; }//ajouter un tableau de product dans la class category




    }
}
