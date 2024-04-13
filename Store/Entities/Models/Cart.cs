namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
                Lines.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }
        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.Id.Equals(product.Id));
        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
