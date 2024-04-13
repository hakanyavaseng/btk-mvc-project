using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowCaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public ShowCaseViewComponent(IServiceManager serviceManager)
        {
            this._manager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _manager.ProductService.GetShowCaseProducts(false);
            return View(products);
        }
    }
}
