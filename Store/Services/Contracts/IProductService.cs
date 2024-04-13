using Entities.DTOs.Product;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(bool trackChanges);
        Task<Product?> GetOneProduct(int productId, bool trackChanges);
        Task<int> GetProductCount();
        Task CreateProduct(ProductDtoForInsertion productDto);
        Task UpdateProduct(ProductDtoForUpdate productDto);
        Task Delete(int id);
        Task<ProductDtoForUpdate> GetOneProductForUpdateAsync(int id, bool trackChanges);
        Task<IEnumerable<ProductListIndexDto>> GetAllProductsWithCategory(bool trackChanges);
        Task<IEnumerable<Product>> GetShowCaseProducts(bool trackChanges);
    }

}