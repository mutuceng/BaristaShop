using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIShoppingCartComponents
{
    public class UIShoppingCartProductsViewComponent:ViewComponent
    {
        private readonly IBasketService _basketService;

        public UIShoppingCartProductsViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _basketService.GetBasketAsync();
            return View(values);
        }
    }
}
