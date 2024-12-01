using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Merchant.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
