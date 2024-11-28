using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class AdminLayoutTopBarViewComponent:ViewComponent
    {
        [Area("Admin")]
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
