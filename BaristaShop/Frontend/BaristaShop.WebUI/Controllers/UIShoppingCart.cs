using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIShoppingCart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
