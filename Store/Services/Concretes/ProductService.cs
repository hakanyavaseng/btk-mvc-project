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

        public Task CreateProduct(Product product)
        {
            repositoryManager.Product.CreateProduct(product);
            return repositoryManager.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await repositoryManager.Product.DeleteAsync(id);
            await repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts(bool trackChanges)
        {
            return await repositoryManager.Product.GetAllProducts(trackChanges)
            .OrderBy(p => p.Id)
            .ToListAsync();
        }

        public async Task<Product?> GetOneProduct(int productId, bool trackChanges)
        {
            var product = await repositoryManager.Product.GetOneProduct(productId, trackChanges);
            if (product is null)
                throw new Exception("Product not found");
            return product;
        }

        public Task<int> GetProductCount() => repositoryManager.Product.GetCount(p => p.Id > 0);

        public async Task UpdateProduct(Product product)
        {
            product.CategoryId = 1;
            var productToUpdate = await repositoryManager.Product.GetOneProduct(product.Id, true);
            if (productToUpdate is null)
                throw new Exception("Product not found");
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;

            await repositoryManager.SaveAsync();


        }
    }
}