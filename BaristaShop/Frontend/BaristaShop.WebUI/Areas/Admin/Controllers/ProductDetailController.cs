using BaristaShop.Catalog.Dtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    [AllowAnonymous]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("CreateProductDetail/{id}")]
        public IActionResult CreateProductDetail(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme II ";


            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        [Route("CreateProductDetail/{id}")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto model)
        {
            if (ModelState.IsValid)
            {
                var createProductDetailDto = new CreateProductDetailDto
                {
                    ProductId = model.ProductId,
                    ProductDescription = model.ProductDescription,
                    ProductInfo = model.ProductInfo,
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/ProductDetails", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CreateProductImage", "ProductImage", new { area = "Admin", id = model.ProductId });
                }
            }
            else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(model);
        }
    }
}
