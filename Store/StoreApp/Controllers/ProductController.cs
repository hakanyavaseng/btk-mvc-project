using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{

    public class ProductController : Controller
    {
        private readonly IServiceManager serviceManager;
        public ProductController(IServiceManager manager)
        {
            serviceManager = manager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await serviceManager.ProductService.GetAllProducts(false));
        }

        public async Task<IActionResult> Get([FromRoute(Name ="id")] int id)
        {
            var product = await serviceManager.ProductService.GetOneProduct(id, false);
            return View(product);
        }

    }
}