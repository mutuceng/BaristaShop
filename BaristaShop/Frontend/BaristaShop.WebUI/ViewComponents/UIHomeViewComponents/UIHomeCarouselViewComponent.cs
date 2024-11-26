using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.HomeViewComponents
{
    public class UIHomeCarouselViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
