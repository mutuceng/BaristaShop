using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductItem")]
    [AllowAnonymous]
    public class ProductItemController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductItemController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("CreateProductItem/{id}")]
        public IActionResult CreateProductItem(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme II ";


            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        [Route("CreateProductItem/{id}")]
        public async Task<IActionResult> CreateProductItem(CreateProductItemDto model)
        {
            if (ModelState.IsValid)
            {
                var createProductItemDto = new CreateProductItemDto
                {
                    ProductId = model.ProductId,
                    ProductPrice = model.ProductPrice,
                    ProductStock = model.ProductStock,
                    SKU = model.SKU,
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductItemDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/ProductItems", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CreateProductDetail", "ProductDetail", new { area = "Admin", id = model.ProductId });
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
