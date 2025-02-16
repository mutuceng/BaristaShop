using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using BaristaShop.WebUI.Services.ApiServices.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    [Authorize]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
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

                    await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

                
                    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
                    
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
