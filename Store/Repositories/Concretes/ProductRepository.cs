using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories.Concretes
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
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

        public IQueryable<Product> GetProductsWithDetails(ProductRequestParameters parameters)
        => _repositoryContext
            .Products
            .FilteredByCategoryId(parameters.CategoryId)
            .Search(parameters.SearchTerm)
            .FilteredByPrice(parameters.MinPrice, parameters.MaxPrice, parameters.ValidPriceRange)
            .ToPaginate(parameters.PageNumber, parameters.PageSize);
            
        public IQueryable<Product> GetShowCaseProducts(bool trackChanges) => FindAll(trackChanges).Where(p => p.ShowCase);
        public Task UpdateProductAsync(Product product) => UpdateAsync(product);
       
    }
}