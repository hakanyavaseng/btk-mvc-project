
using Repositories.Contracts;

namespace Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private readonly IProductRepository _productRepository;
        public RepositoryManager(RepositoryContext repositoryContext, IProductRepository productRepository)
        {
            _repositoryContext = repositoryContext;
            _productRepository = productRepository;
        }

        public IProductRepository Product => _productRepository;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}