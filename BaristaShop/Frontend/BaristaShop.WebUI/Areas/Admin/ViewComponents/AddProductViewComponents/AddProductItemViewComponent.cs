using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.ViewComponents.AddProductViewComponents
{
    [Area("Admin")]
    public class AddProductItemViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
