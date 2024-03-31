using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        Task<Product?> GetOneProduct(int id, bool trackChanges);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}