using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    [Route("")]
    public class UIHomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
