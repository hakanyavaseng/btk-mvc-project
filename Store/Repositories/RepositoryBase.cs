using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<int> GetCount(Expression<Func<T, bool>> expression)
        {
            return await Table.Where(expression).CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _repositoryContext.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await Table.FindAsync(id);

            if(entity is null)
             throw new ArgumentNullException(nameof(entity));
            else
             await Task.Run(() => _repositoryContext.Remove(entity)); 

        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _repositoryContext.Update(entity));
        }
    }

}