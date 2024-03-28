using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _repositoryContext;
        private DbSet<T> Table => _repositoryContext.Set<T>();

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? Table : Table.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? Table.Where(expression) : Table.Where(expression).AsNoTracking();
          
        }
    }

}