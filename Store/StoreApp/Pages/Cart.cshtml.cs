using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager serviceManager;
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager serviceManager, Cart cart)
        {
            this.serviceManager = serviceManager;
            Cart = cart;
        }
        public Cart Cart { get;  set; }
    
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public async Task<IActionResult> OnPost(int id, string returnUrl)
        {
            Product? product = await serviceManager.ProductService.GetOneProduct(id,false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page(); // returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id == id).Product);
            return Page();
        }
    }
}
