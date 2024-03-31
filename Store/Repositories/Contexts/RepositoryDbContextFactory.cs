using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repositories
{
    public class RepositoryDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //Options
			DbContextOptionsBuilder<RepositoryContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
			return new RepositoryContext(dbContextOptionsBuilder.Options);  
           
        }
    }
}