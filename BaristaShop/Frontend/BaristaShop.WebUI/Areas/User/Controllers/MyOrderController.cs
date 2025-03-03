using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
