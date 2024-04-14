using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await serviceManager.ProductService.GetAllProducts(false);
            return Ok(products);
        }
    }
}
