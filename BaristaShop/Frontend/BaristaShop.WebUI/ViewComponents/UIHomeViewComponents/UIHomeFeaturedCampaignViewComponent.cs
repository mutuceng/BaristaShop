using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.UIHomeViewComponents
{
    public class UIHomeFeaturedCampaignViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UIHomeFeaturedCampaignViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/SpecialOffers");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

                return View(products);
            }

            return View(new List<ResultSpecialOfferDto>()); // Return an empty list if no data
        }
    }
}
