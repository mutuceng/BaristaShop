using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
