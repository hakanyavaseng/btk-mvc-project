namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = int.MaxValue;
        public bool ValidPriceRange => MaxPrice >= MinPrice && MinPrice >= 0;
    }
}
