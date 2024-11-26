using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIProductDetailComponents
{
    public class UIProductDetailViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
