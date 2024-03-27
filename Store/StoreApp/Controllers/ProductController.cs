using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;

namespace StoreApp.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly RepositoryContext context;

        public ProductController(RepositoryContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await context.Products.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Get(int id)
        {
            Product? product =  await context.Products.FindAsync(id);
            return View(product);
        }

    }
}