using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UITopBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
