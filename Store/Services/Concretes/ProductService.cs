using AutoMapper;
using Entities.DTOs.Product;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = mapper.Map<Product>(productDto);
            await repositoryManager.Product.CreateProductAsync(product);
            await repositoryManager.SaveAsync();
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

        public async Task<IEnumerable<ProductListIndexDto>> GetAllProductsWithCategory(bool trackChanges)
        {
            return await repositoryManager.Product.GetAllProducts(trackChanges)
                .Include(p => p.Category)
                .Select(p => new ProductListIndexDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    CategoryId = p.CategoryId
                })
                .ToListAsync();
        }

        public async Task<Product?> GetOneProduct(int productId, bool trackChanges)
        {
            var product = await repositoryManager.Product.GetOneProduct(productId, trackChanges);
            if (product is null)
                throw new Exception("Product not found");
            return product;
        }

        public async Task<ProductDtoForUpdate> GetOneProductForUpdateAsync(int id, bool trackChanges)
        {
            var product = await repositoryManager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
                throw new Exception("Product not found");
            return mapper.Map<ProductDtoForUpdate>(product);
        }

        public Task<int> GetProductCount() => repositoryManager.Product.GetCount(p => p.Id > 0);

        public async Task UpdateProduct(ProductDtoForUpdate productDto)
        {
            var product = await repositoryManager.Product.GetOneProduct(productDto.Id, false);
            if (product is null)
                throw new Exception("Product not found");
            product = mapper.Map<Product>(productDto);
            await repositoryManager.Product.UpdateProductAsync(product);
            await repositoryManager.SaveAsync();
        }
    }
}