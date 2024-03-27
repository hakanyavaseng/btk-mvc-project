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
            if (Repository.Applications.Where(c => c.Email == candidate.Email).Any())
                ModelState.AddModelError("Email", "This email is already in use.");
            if (ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("Feedback", candidate);
            }
            return View(candidate);
        }

        [HttpGet]
        public IActionResult Applications()
        {
            return Ok(Repository.Applications);

        }
    }
}