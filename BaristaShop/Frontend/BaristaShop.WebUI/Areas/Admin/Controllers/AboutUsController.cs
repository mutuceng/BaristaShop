using BaristaShop.DtoLayer.Dtos.CatalogDtos.AboutUsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AboutUs")]
    [AllowAnonymous]
    public class AboutUsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutUsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/AboutUs");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAboutUsDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateAboutUs")]
        public IActionResult CreateAboutUs()
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Hakkımda";



            return View();
        }

        [HttpPost]
        [Route("CreateAboutUs")]
        public async Task<IActionResult> CreateAboutUs(CreateAboutUsDto createAboutUsDto)
        {
            ViewBag.v0 = "Anasayfa İşlemleri";
            ViewBag.v1 = "Hakkımda";

            if (ModelState.IsValid)
            {
                var CreateAboutUsDto = new CreateAboutUsDto
                {
                    AboutInfo = createAboutUsDto.AboutInfo,
                    AboutEmail = createAboutUsDto.AboutEmail,
                    AboutPhone = createAboutUsDto.AboutPhone
                };


                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(CreateAboutUsDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/AboutUs", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AboutUs", new { area = "Admin" });
                }
            }

            return View();
        }
    }
}
