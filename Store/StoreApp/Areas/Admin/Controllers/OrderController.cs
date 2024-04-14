using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin,Editor")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            await _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}
