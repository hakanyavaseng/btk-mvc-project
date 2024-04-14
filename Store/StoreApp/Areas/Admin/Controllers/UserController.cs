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

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            UserDtoForUpdate user = await _serviceManager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto() { UserName = id });
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

        [HttpPost]
        public async Task<IActionResult> Update(UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.Update(userDto);
                return RedirectToAction("Index");
            }
            return View(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _serviceManager.AuthService.ResetPassword(resetPasswordDto);
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
            return View(resetPasswordDto);

        }


    }
}
