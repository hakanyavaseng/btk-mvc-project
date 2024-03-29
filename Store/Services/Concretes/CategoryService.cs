using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges)
        {
            return await repositoryManager.Category.FindAll(trackChanges).ToListAsync();
        }
    }

}