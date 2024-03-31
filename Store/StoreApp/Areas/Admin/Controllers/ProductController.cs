using Entities.DTOs.Product;
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
            var products = await _manager.ProductService.GetAllProductsWithCategory(false);
            return View(products);
        }

        #region Create Product
        public async Task<IActionResult> Create()
        {
           ViewBag.Categories = new SelectList(await _manager.CategoryService.GetAllCategories(false), nameof(Category.Id), nameof(Category.Name), "1");
           return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion product) // TODO : Use ProductViewModel
        {
            await _manager.ProductService.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update Product
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = new SelectList(await _manager.CategoryService.GetAllCategories(false), nameof(Category.Id), nameof(Category.Name), "1");
            return View(await _manager.ProductService.GetOneProductForUpdateAsync(id,false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate product)
        { 
            await _manager.ProductService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
          
        }
        #endregion

        #region Delete Product
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _manager.ProductService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}