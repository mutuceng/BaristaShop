using BaristaShop.DtoLayer.Dtos.BasketDtos;
using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using BaristaShop.WebUI.Services.ApiServices.DiscountServices;
using BaristaShop.WebUI.Services.ApiServices.ProductItemServices;
using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIShoppingCart : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductItemService _productItemService;
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public UIShoppingCart(IProductService productService, IBasketService basketService, IProductItemService productItemService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _productItemService = productItemService;
            _discountService = discountService;
        }

        public async Task<IActionResult> Index(string code, int couponRate, double totalNewPriceWithDiscount)
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            ViewBag.code = code;
            ViewBag.discountRate = couponRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;


            var values = await _basketService.GetBasketAsync();
            ViewBag.total = values.TotalPrice;
            
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.tax = tax;

            var totelPriceWithTax = values.TotalPrice + tax;

            ViewBag.totalWithTax = totelPriceWithTax;


            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var price = await _productItemService.GetProductItemByProductIdAsync(id);

            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = price.ProductPriceWithSale,
                Quantity = 1
            };

            await _basketService.AddItemToBasketAsync(items);

            return RedirectToAction("Index", "ProductList");
            // ajax ile sayfanın yenilenmesi engellenebilir.
        }

        public async Task<IActionResult> RemoveItemFromBasket(string productId)
        {
            await _basketService.DeleteItemFromBasketAsync(productId);
            return RedirectToAction("Index");
        }
    }
}
