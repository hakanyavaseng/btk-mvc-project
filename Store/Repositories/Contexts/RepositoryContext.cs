
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { Id = 1, Name = "Product 1", Price = 100, CategoryId = 1},
                new Product { Id = 2, Name = "Product 2", Price = 200, CategoryId = 2},
                new Product { Id = 3, Name = "Product 3", Price = 300, CategoryId = 1},
                new Product { Id = 4, Name = "Product 4", Price = 400, CategoryId = 2},
                new Product { Id = 5, Name = "Product 5", Price = 500, CategoryId = 1});

            modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Computer" },
                new Category { Id = 2, Name = "Books" });
        }

    }
}