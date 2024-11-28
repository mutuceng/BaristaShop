using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult _AdminLayout() // area oldugunda index kullandım _AdminLayout ile olmadı
        {
            return View();
        }
    }
}
