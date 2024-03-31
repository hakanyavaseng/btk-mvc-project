using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _manager.ProductService.GetAllProducts(false);
            return View(products);
        }


        public async Task<IActionResult> Create()
        {
           ViewBag.Categories = new SelectList(await _manager.CategoryService.GetAllCategories(false), nameof(Category.Id), nameof(Category.Name), "1");
           return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product) // TODO : Use ProductViewModel
        {
            product.CategoryId = 1;
            await _manager.ProductService.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _manager.ProductService.GetOneProduct(id,false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Product product)
        { 
            await _manager.ProductService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
          
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _manager.ProductService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}