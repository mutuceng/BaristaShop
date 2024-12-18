using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    [AllowAnonymous]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/FeatureSliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider( )
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Feature Slider";


            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(AddFeatureSlideImageViewModel model)
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Feature Slider";

            if (ModelState.IsValid)
            {
                string folder = Path.Combine("wwwroot", "images", "homepageImages", "featureSlider");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (model.FeatureSliderImage != null && model.FeatureSliderImage.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.FeatureSliderImage.FileName);

                    string filePath = Path.Combine(folder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.FeatureSliderImage.CopyToAsync(fileStream);
                    }

                    string relativePath = Path.Combine("images", "homepageImages", "featureSlider", uniqueFileName).Replace("\\", "/");


                    var createFeatureSliderDto = new CreateFeatureSliderDto
                    {
                        FeatureSliderDescription = model.FeatureSliderDescription,
                        FeatureSliderTitle = model.FeatureSliderTitle,
                        FeatureSliderImage = relativePath
                    };

                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://localhost:7080/api/FeatureSliders", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
                    }
                }


            } else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }


            return View(model);
        }
    }
}
