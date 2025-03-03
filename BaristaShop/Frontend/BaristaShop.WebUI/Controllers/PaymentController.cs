using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBasketService _basketService;

        public PaymentController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(int AddressId, decimal DiscountRate)
        {
            var basket = await _basketService.GetBasketAsync();
            ViewBag.addresId = AddressId;
            

            return View();
        }

        public IActionResult Ordering(int AddressId) 
        {
            return View();
        }
    }
}
