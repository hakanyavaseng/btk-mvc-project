using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;

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