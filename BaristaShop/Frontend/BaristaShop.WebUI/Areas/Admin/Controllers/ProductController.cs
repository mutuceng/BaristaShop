using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.WebUI.Services.ApiServices.CategoryServices;
using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        IHttpClientFactory _httpClientFactory;
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürünler";


           var values = await _productService.GetAllProductAsync();

            return View(values);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme";


            var categories = await _categoryService.GetAllCategoryAsync();

            // Kategorileri SelectListItem listesine dönüştürüyoruz
            List<SelectListItem> categoryList = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            }).ToList();

            // ViewBag ile kategorileri gönderiyoruz
            ViewBag.Categories = categoryList;

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

                await _productService.CreateProductAsync(createProductDto);

                var products = await _productService.GetAllProductAsync();
   
                foreach(var value in products)
                {
                    if(value.ProductName == model.ProductName)
                    {
                        return RedirectToAction("CreateProductItem", "ProductItem", new { area = "Admin" , id = value.ProductId});
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
