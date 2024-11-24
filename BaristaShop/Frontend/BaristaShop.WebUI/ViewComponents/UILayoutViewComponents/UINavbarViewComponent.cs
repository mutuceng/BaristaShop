using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UINavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
