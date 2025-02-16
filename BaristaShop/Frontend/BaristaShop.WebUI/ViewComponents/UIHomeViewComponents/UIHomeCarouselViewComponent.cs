using BaristaShop.Catalog.Entities;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.FeatureSliderServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.HomeViewComponents
{
    public class UIHomeCarouselViewComponent : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public UIHomeCarouselViewComponent(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var featureSliders = await _featureSliderService.GetAllFeatureSliderAsync();

            return View(featureSliders); // Return an empty list if no data
        }
    }
}
