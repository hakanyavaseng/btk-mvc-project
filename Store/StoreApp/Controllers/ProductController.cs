using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;

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
            var products = serviceManager.ProductService.GetProductsWithDetails(parameters);
            var count = await serviceManager.ProductService.GetProductCount();
            var pagination = new Pagination()
            {
                CurrentPage = parameters.PageNumber,
                ItemsPerPage = parameters.PageSize,
                TotalItems = count
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
        public async Task<IActionResult> Get([FromRoute(Name ="id")] int id)
        {
            var product = await serviceManager.ProductService.GetOneProduct(id, false);
            return View(product);
        }

    }
}