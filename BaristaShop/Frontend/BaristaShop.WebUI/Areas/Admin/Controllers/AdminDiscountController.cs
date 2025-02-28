using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    public class AdminDiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
