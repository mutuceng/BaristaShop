using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

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

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme";


            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categories = (from x in values
                                                         select new SelectListItem
                                                         {
                                                             Text = x.CategoryName,
                                                             Value = x.CategoryId
                                                         }).ToList();

                ViewBag.Categories = categories;
            }

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto model)
        {
            if (ModelState.IsValid)
            {
    

                var createProductDto = new CreateProductDto
                {
                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,  
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/Products", content);

                if (response.IsSuccessStatusCode)
                {
                    var clientId = _httpClientFactory.CreateClient();
                    var responseId = await client.GetAsync("https://localhost:7080/api/Products");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonDataId = await responseId.Content.ReadAsStringAsync();
                        var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonDataId);
                        foreach(var value in values)
                        {
                            if(value.ProductName == model.ProductName)
                            {
                                return RedirectToAction("CreateProductItem", "ProductItem", new { area = "Admin" , id = value.ProductId});
                            }
                        }
                    }
                    
                }
            }
            else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

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
