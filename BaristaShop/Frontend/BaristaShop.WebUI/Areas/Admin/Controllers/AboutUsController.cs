using BaristaShop.DtoLayer.Dtos.CatalogDtos.AboutUsDtos;
using BaristaShop.WebUI.Services.ApiServices.AboutUsServices;
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
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var value = await _aboutUsService.GetAboutUsAsync();

            return View(value);
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

                await _aboutUsService.CreateAboutUsAsync(CreateAboutUsDto);

                return RedirectToAction("Index", "AboutUs", new { area = "Admin" });
               
            }

            return View();
        }
    }
}
