using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetProductsWithDetails(ProductRequestParameters parameters);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges);
        Task<Product?> GetOneProduct(int id, bool trackChanges);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);


    }
}