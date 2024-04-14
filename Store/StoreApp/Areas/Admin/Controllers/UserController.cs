using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_serviceManager.AuthService.Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_serviceManager.AuthService.Roles.Select(r => r.Name))
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDtoForCreation userDto)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _serviceManager.AuthService.CreateUser(userDto);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                   foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }      
            }
            return View(userDto);
        }
    }
}
