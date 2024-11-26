using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
