using BaristaShop.DtoLayer.Dtos.BasketDtos;
using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using BaristaShop.WebUI.Services.ApiServices.ProductItemServices;
using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UIShoppingCart : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductItemService _productItemService;
        private readonly IBasketService _basketService;

        public UIShoppingCart(IProductService productService, IBasketService basketService, IProductItemService productItemService)
        {
            _productService = productService;
            _basketService = basketService;
            _productItemService = productItemService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasketAsync();
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
