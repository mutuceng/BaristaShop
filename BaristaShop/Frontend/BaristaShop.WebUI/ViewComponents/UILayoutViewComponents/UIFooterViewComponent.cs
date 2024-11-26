using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UIFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
