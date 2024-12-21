using BaristaShop.WebUI.Services.ProductDataServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIProductListViewComponents
{
    public class UIProductListProductsViewComponent : ViewComponent
    {
        private readonly IProductDataService _productDataService;

        public UIProductListProductsViewComponent(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productDataService.GetAllProductPrevDataAsync();
            return View(products);
        }
    }
}
