using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaristaShop.WebUI.ViewComponents.UIHomeViewComponents
{
    public class UIHomeFeaturedProductsViewComponent:ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        public IViewComponentResult Invoke()
        {
            //var client = _httpClientFactory.CreateClient();


            //var productResponse = await client.GetAsync("https://localhost:7080/api/Products");
            //if (!productResponse.IsSuccessStatusCode)
            //{
            //    return View();
            //}
            //var productJsonData = await productResponse.Content.ReadAsStringAsync();
            //var productValues = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJsonData);

            //var productItemResponse = await client.GetAsync("https://localhost:7080/api/ProductItems");
            //if(!productItemResponse.IsSuccessStatusCode)
            //{
            //    return View();
            //}
            //var productItemJsonData = await productItemResponse.Content.ReadAsStringAsync();
            //var productItemValues = JsonConvert.DeserializeObject<List<ResultProductItemDto>>(productItemJsonData);


            return View();
        }
    }
}
