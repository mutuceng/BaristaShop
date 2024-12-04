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
        public IActionResult CreateCategoryFeature()
        {
            ViewBag.v0 = "Kategori Özellik İşlemleri";
            ViewBag.v1 = "Kategori Özellik Ekleme";
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
                var client = _httpClientFactory.CreateClient();

                // Feature Values için liste
                var categoryFeatureValues = new List<CategoryFeatureValue>();

                // formdan gelen string liste
                var formattedList = FormatFeatureValues(model.CategoryFeatureValues);
                foreach (var feature in formattedList)
                {
                    var createCategoryFeatureValueDto = new CreateCategoryFeatureValueDto
                    {
                        CategoryFeatureValueId = ObjectId.GenerateNewId().ToString(),
                        CategoryFeatureValueName = feature
                    };

                    var jsonData = JsonConvert.SerializeObject(createCategoryFeatureValueDto);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://localhost:7080/api/CategoryFeatureValues", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Başarıyla kaydedilen DTO'yu CategoryFeatureValue'ya mapleyerek listeye ekle
                        categoryFeatureValues.Add(new CategoryFeatureValue
                        {
                            CategoryFeatureValueId = createCategoryFeatureValueDto.CategoryFeatureValueId,
                            CategoryFeatureValueName = createCategoryFeatureValueDto.CategoryFeatureValueName
                        });


                    }
                }

                var createCategoryFeatureDto = new CreateCategoryFeatureDto
                {
                    CategoryFeatureName = model.CategoryFeatureName,
                    CategoryFeatureValues = categoryFeatureValues
                };
                
                var categoryFeatureClient = _httpClientFactory.CreateClient();

                var categoryFeatureJson = JsonConvert.SerializeObject(createCategoryFeatureDto);
                StringContent categoryFeatureContent = new StringContent(categoryFeatureJson, Encoding.UTF8, "application/json");
                var categoryFeatureResponse = await categoryFeatureClient.PostAsync("https://localhost:7080/api/CategoryFeatures", categoryFeatureContent);

                if (categoryFeatureResponse.IsSuccessStatusCode)
                {
                    // Başarı durumunda yönlendirme yapabiliriz
                    return View();

                }

            }

            return View(model);
        }

        public List<string> FormatFeatureValues(List<string> featureValues)
        {
            return featureValues.Select(value =>
                char.ToUpper(value[0]) + value.Substring(1).ToLower()
            ).ToList();
        }

        public string GetCategoryFeatureValueId()
        {

            return "5";
        }

    }
}
