namespace productslist.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; } // Price in INR
    }
}
