using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Merchant.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Merchant")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
