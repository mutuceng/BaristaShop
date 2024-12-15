using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductItem")]
    [AllowAnonymous]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("CreateProductImage/{id}")]
        public IActionResult CreateProductImage(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme II ";


            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        [Route("CreateProductImage/{id}")]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto model)
        {
            if (ModelState.IsValid)
            {
                var createProductImageDto = new CreateProductImageDto
                {
                    Images = model.Images,
                    ProductId = model.ProductId
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductImageDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/ProductDetails", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product", new { area = "Admin" });
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
