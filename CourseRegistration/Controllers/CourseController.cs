using CourseRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Apply() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents CSRF attacks. 
        public IActionResult Apply([FromForm] Candidate candidate) 
        {
            return View(candidate);
        }
    }
}