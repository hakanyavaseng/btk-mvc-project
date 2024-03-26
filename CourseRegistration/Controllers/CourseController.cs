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

        [Route("Apply")]
        public IActionResult Apply() 
        {
            return View();
        }


       
    }
}