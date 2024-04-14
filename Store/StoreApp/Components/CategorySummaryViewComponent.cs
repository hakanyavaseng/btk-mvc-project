using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategorySummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<string> InvokeAsync()
        {
            var categories = await _manager.CategoryService.GetAllCategories(false);
            return categories.Count().ToString();
        }

    }
}