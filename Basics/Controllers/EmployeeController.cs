using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index1()
        {
            string message = $"Hello World. {DateTime.Now.ToString()}";

            return View("Index1", message);
        }

        public ViewResult Index2()
        {
            var messages = new String[] {
                "Hello World",
                "Hello ASP.NET Core",
                "Hello MVC"
            };

            return View(messages);
        }

        public IActionResult Index3()
        {
            var list = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Hakan", LastName = "Yavaş" },
                new Employee { Id = 2, FirstName = "Alperen", LastName = "Güneş" },
                new Employee { Id = 3, FirstName = "Ceyda", LastName = "Kesgin" }
            };

            return View(list);
        }

    }
}