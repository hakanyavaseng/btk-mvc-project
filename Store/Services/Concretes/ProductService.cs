using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;

        public ProductService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<Product>> GetAllProducts(bool trackChanges)
        {
            return await repositoryManager.Product.GetAllProducts(trackChanges).ToListAsync();
        }

        public async Task<Product?> GetOneProduct(int productId, bool trackChanges)
        {
            var product = await repositoryManager.Product.GetOneProduct(productId, trackChanges);
            if(product is null)
                throw new Exception("Product not found");
            return product;
        }
    }
}