using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    [Route("ProductList")]
    public class UIProductListController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ProductDetails/{productId}")]
        public IActionResult ProductDetails(string productId)
        {

            return View("ProductDetails", productId);
        }
    }
}
