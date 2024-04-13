using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Order 
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? City { get; set; }
        public bool GiftWrap { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
        public bool Shipped { get; set; }
    }
}
