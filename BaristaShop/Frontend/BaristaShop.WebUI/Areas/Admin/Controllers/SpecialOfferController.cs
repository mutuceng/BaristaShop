using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    [AllowAnonymous]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/SpecialOffers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Feature Slider";


            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(AddSpecialOfferImageViewModel model)
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Feature Slider";

            if (ModelState.IsValid)
            {
                string folder = Path.Combine("wwwroot", "images", "homepageImages", "specialOffer");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (model.SpecialOfferImage != null && model.SpecialOfferImage.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.SpecialOfferImage.FileName);

                    string filePath = Path.Combine(folder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.SpecialOfferImage.CopyToAsync(fileStream);
                    }

                    string relativePath = Path.Combine("images", "homepageImages", "specialOffer", uniqueFileName).Replace("\\", "/");


                    var createSpecialOfferDto = new CreateSpecialOfferDto
                    {
                        SpecialOfferTitle = model.SpecialOfferTitle,
                        SpecialOfferSubTitle = model.SpecialOfferSubTitle,
                        SpecialOfferImage = relativePath
                    };

                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://localhost:7080/api/SpecialOffers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
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
    }
}
