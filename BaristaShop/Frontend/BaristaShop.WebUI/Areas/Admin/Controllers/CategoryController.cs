using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
