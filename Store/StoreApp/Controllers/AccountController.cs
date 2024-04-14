using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpGet]
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
           
        }

        [HttpGet]
        public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")] string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if(ModelState.IsValid)
            {
                if(!(model.Password.Equals(model.PasswordConfirm)))
                {
                    ModelState.AddModelError("Error", "Passwords do not match");
                    return View(model);
                }

                IdentityUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");  
                    return RedirectToAction("Login", "Account", new { ReturnUrl = "/"});
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("Error", error.Description);
                    }
                    return View(model);
                }
            } 
            else
                return View(model);
        }
    }
}
