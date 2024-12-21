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
        public IViewComponentResult Invoke(string productId)
        {
            var product = _productDataService.GetProductDataAsync(productId);
            return View(product);
        }
    }
}
