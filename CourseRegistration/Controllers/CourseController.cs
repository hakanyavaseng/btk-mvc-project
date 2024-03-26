using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }


       
    }
}