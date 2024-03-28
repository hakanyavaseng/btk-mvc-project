using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _manager.Product.GetAllProducts(false).ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

    }
}