using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryFeatureDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryFeatureValueDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using BaristaShop.Catalog.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CategoryFeature")]
    [AllowAnonymous]
    public class CategoryFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.v0 = "Kategori Özellik İşlemleri";
            ViewBag.v1 = "Kategori Özellik Listesi";
            return View();
        }



        [HttpGet]
        [Route("CreateCategoryFeature")]
        public async Task<IActionResult> CreateCategoryFeature()
        {
            ViewBag.v0 = "Kategori Özellik İşlemleri";
            ViewBag.v1 = "Kategori Özellik Ekleme";
            
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/CategoryFeatureValues");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryFeatureValueDto>>(jsonData);

                List<SelectListItem> categoryFeatureValues = (from x in values
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.CategoryFeatureValueName,
                                                                  Value = x.CategoryFeatureValueId
                                                              }).ToList();

                ViewBag.CategoryFeatureValues = categoryFeatureValues;
            }

            return View();
        }

        [HttpPost]
        [Route("CreateCategoryFeature")]
        public async Task<IActionResult> CreateCategoryFeature(CreateCategoryFeatureViewModel model)
        {
            ViewBag.v0 = "Kategori Özellik İşlemleri";
            ViewBag.v1 = "Kategori Özellik Ekleme";

            if (ModelState.IsValid)
            {
                var list = model.CategoryFeatureValues.Split(',').ToList();

                var client = _httpClientFactory.CreateClient();

                var createCategoryFeatureDto = new CreateCategoryFeatureDto
                {
                    CategoryFeatureName = model.CategoryFeatureName,
                    CategoryFeatureValues = list
                };

                var categoryFeatureJson = JsonConvert.SerializeObject(createCategoryFeatureDto);
                StringContent categoryFeatureContent = new StringContent(categoryFeatureJson, Encoding.UTF8, "application/json");
                var categoryFeatureResponse = await client.PostAsync("https://localhost:7080/api/CategoryFeatures", categoryFeatureContent);

                if (categoryFeatureResponse.IsSuccessStatusCode)
                {
                    // Başarı durumunda yönlendirme yapabiliriz
                    return RedirectToAction("Index", "CategoryFeature", new { area = "Admin" });
                }
            }                    
           return View(model);
        }


    }
}
