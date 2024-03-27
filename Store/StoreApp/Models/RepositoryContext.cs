
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { Id = 1, Name = "Product 1", Price = 100},
                new Product { Id = 2, Name = "Product 2", Price = 200},
                new Product { Id = 3, Name = "Product 3", Price = 300},
                new Product { Id = 4, Name = "Product 4", Price = 400},
                new Product { Id = 5, Name = "Product 5", Price = 500});
        }
        
    }
}