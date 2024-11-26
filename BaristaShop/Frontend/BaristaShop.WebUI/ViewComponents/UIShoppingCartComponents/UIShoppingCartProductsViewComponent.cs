using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIShoppingCartComponents
{
    public class UIShoppingCartProductsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
