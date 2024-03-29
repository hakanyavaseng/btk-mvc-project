using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components 
{
    public class ProductSummary : ViewComponent 
    {  
        private readonly IServiceManager serviceManager;

        public ProductSummary(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public async Task<string> InvokeAsync() 
        {
            return (await serviceManager.ProductService.GetProductCount()).ToString();
        }


    }
}