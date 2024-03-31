namespace Entities.DTOs.Product
{
    public record ProductListIndexDto : ProductDto
    {
        public int Id { get; init; }
        public string CategoryName { get; init; } 
    }
}
