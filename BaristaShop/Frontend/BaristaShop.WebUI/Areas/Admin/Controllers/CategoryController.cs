using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Ekleme";


            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("https://localhost:7080/api/CategoryFeatures");
            //if(response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultVariantDto>>(jsonData);

            //    List<SelectListItem> CategoryFeatures = (from x in values
            //                                             select new SelectListItem
            //                                             {
            //                                                 Text = x.CategoryFeatureName,
            //                                                 Value = x.CategoryFeatureId
            //                                             }).ToList();

            //    ViewBag.CategoryFeatures = CategoryFeatures;
            //}
           
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                

                var createCategoryDto = new CreateCategoryDto
                {
                    CategoryName = model.CategoryName,
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCategoryDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/Categories", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Category", new { area = "Admin" });
                }
            }
            else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(model);
        }

        
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7080/api/Categories?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View();

        }

        // silme işlemi için https://localhost:7080/api/Categories?id=id
        // güncelleme için   https://localhost:7080/api/Categories/id

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Categories/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if(ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("https://localhost:7080/api/Categories", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Category", new { area = "admin" });
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }


            return View(updateCategoryDto);
        }
    }
}
