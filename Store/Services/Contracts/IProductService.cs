using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(bool trackChanges);
        Task<Product?> GetOneProduct(int productId, bool trackChanges);
        Task<int> GetProductCount();
    }

}