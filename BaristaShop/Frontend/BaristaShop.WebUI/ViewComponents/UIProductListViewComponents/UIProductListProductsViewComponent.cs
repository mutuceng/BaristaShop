using Microsoft.AspNetCore.Mvc;
namespace BaristaShop.WebUI.ViewComponents.UIProductListViewComponents
{
    public class UIProductListProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
