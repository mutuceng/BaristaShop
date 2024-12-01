using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürünler";

            // API'den verileri al
            var products = await FetchDataAsync<List<ResultProductDto>>("https://localhost:7080/api/Products");
            var productDetails = await FetchDataAsync<List<ResultProductDetailDto>>("https://localhost:7080/api/ProductDetails");
            var productImages = await FetchDataAsync<List<ResultProductImageDto>>("https://localhost:7080/api/ProductImages");

            // ViewModel'i oluştur
            var model = new ProductListViewModel
            {
                Products = products ?? new List<ResultProductDto>(),
                ProductDetails = productDetails ?? new List<ResultProductDetailDto>(),
                ProductImages = productImages ?? new List<ResultProductImageDto>()
            };

            return View(model);
        }

        // Genel bir API çağrısı yapmak için yardımcı yöntem
        private async Task<T?> FetchDataAsync<T>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }
    }
}
