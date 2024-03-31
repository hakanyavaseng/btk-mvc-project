namespace Entities.DTOs.Product
{
    public record ProductDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
    }
}
