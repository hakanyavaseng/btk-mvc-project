using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {

      
        public async Task<IActionResult> GetCategories()
        {
            return View("Index",await repositoryManager.Category.FindAll(false).ToListAsync());
        }

      
        
    }
}