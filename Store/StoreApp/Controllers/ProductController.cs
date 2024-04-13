using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index(ProductRequestParameters parameters)
        {
            return View(serviceManager.ProductService.GetProductsWithDetails(parameters));
        }

        public async Task<IActionResult> Get([FromRoute(Name ="id")] int id)
        {
            var product = await serviceManager.ProductService.GetOneProduct(id, false);
            return View(product);
        }

    }
}