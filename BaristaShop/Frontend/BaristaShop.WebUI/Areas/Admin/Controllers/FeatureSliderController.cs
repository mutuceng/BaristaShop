using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using BaristaShop.WebUI.Services.ApiServices.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    [Authorize]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            
            var values = await _featureSliderService.GetAllFeatureSliderAsync();

            return View(values);
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

                    await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

                    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
                    
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
