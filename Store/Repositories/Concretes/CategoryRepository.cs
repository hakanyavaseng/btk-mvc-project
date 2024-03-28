
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Concretes
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}