using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            this.cart = cartService;
        }

        public string Invoke()
        {
            return cart.Lines.Count().ToString();
        }
    }
}
