using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

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

    }
}