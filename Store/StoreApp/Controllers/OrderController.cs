using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager _manager, Cart cart)
        {
            this._manager = _manager;
            _cart = cart;
        }
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm]Order order)
        {
            if(_cart.Lines.Count == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty!");

            if(ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                await _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new {OrderId = order.OrderId});
            }
            else
                return View(order);    
        }
    }
}
