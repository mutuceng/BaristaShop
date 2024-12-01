using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.Merchant.Controllers
{
    public class MerchantLayoutController : Controller
    {
        [Area("Merchant")]
        public IActionResult _MerchantLayout()
        {
            return View();
        }
    }
}
