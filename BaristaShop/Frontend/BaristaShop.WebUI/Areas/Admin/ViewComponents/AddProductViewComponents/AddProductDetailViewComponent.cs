using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.ViewComponents.AddProductViewComponents
{
    public class AddProductDetailViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
