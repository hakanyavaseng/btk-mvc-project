namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string? Summary { get; set; } = String.Empty;  
        public string? ImageUrl { get; set; } = String.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
    }
}