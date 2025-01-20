using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using BaristaShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.HomeViewComponents
{
    public class UIHomeCarouselViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UIHomeCarouselViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/FeatureSliders");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

                return View(products);
            }

            return View(new List<ResultFeatureSliderDto>()); // Return an empty list if no data
        }
    }
}
