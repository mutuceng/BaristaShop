using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult _AdminLayout() 
        {
            return View();
        }
    }
}
