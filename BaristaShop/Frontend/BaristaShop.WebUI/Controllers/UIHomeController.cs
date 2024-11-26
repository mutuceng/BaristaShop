using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
