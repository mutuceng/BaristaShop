using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UILoginViewComponents
{
    public class UILoginViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
