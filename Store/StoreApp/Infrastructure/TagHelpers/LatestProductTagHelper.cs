using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LatestProductTagHelper : TagHelper
    {
        private readonly IServiceManager serviceManager;

        public LatestProductTagHelper(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");
            
            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.Append(" Latest Products");

            TagBuilder ul = new TagBuilder("ul");
            var products = await serviceManager.ProductService.GetLatestProducts(5, false);
            foreach (Product product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/product/get/{product.Id}");
                a.InnerHtml.Append(product.Name);

                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
             
            }

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);


        }
    }
}

