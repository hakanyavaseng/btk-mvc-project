using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public async Task<IActionResult> GetCategories()
        {
            return View("Index",await serviceManager.CategoryService.GetAllCategories(false));
        }

      
        
    }
}