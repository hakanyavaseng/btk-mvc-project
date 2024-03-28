using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepositoryManager repositoryManager;

        public CategoryController(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<IActionResult> GetCategories()
        {
            return View("Index",await repositoryManager.Category.FindAll(false).ToListAsync());
        }

      
        
    }
}