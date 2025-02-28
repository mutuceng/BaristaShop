using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using BaristaShop.WebUI.Services.ApiServices.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }


        [HttpGet]
        public async Task<PartialViewResult> ConfirmDiscountCoupon()
        {
            var values = await _basketService.GetBasketAsync();
            ViewBag.total = values.TotalPrice;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            
            var values = await _discountService.GetCodeDetailAsync(code);
            var couponRate = values.DiscountRate;

            var basketValues = await _basketService.GetBasketAsync();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * couponRate);

            return RedirectToAction("Index", "UIShoppingCart", new { code = code, couponRate = couponRate, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
