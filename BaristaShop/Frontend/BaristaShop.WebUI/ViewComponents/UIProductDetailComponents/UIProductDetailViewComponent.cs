using BaristaShop.WebUI.Services.ProductDataServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIProductDetailComponents
{
    public class UIProductDetailViewComponent:ViewComponent
    {
        private readonly IProductDataService? _productDataService;

        public UIProductDetailViewComponent(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var product = await _productDataService.GetProductDataAsync(productId);

            if(product == null)
            {
                return View();
            }
            return View(product);
        }
    }
}
