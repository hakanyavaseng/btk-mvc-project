using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                 .HasData(
                   new Product { Id = 1, Name = "Product 1", Price = 100, ImageUrl = "/images/1.jpg", CategoryId = 1 },
                   new Product { Id = 2, Name = "Product 2", Price = 200, ImageUrl = "/images/2.jpg", CategoryId = 2 },
                   new Product { Id = 3, Name = "Product 3", Price = 300, ImageUrl = "/images/3.jpg", CategoryId = 1 },
                   new Product { Id = 4, Name = "Product 4", Price = 400, ImageUrl = "/images/4.jpg", CategoryId = 2 },
                   new Product { Id = 5, Name = "Product 5", Price = 500, ImageUrl = "/images/5.jpg", CategoryId = 1 });

        }
    }
}
