using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Concretes
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task CreateProductAsync(Product product) => CreateAsync(product);
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        public async Task<Product?> GetOneProduct(int id, bool trackChanges) 
        {
            return await FindByCondition(p => p.Id == id, trackChanges).FirstOrDefaultAsync();
        }
        public IQueryable<Product> GetShowCaseProducts(bool trackChanges) => FindAll(trackChanges).Where(p => p.ShowCase);
        public Task UpdateProductAsync(Product product) => UpdateAsync(product);
       
    }
}