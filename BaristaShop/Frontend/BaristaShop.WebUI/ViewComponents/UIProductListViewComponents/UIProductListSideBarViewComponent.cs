using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIProductListViewComponents
{
    public class UIProductListSideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
