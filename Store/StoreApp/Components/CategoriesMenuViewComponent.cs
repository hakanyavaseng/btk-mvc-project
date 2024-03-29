using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager serviceManager;

        public CategoriesMenuViewComponent(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await serviceManager.CategoryService.GetAllCategories(false);
            return View(categories);
        }
    }
}