using BaristaShop.Catalog.Dtos.ProductDetailDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ProductDataServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.UIProductDetailComponents
{
    public class UIProductDetailInfoReviewViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UIProductDetailInfoReviewViewComponent(IHttpClientFactory HttpClientFactory)
        {
            _httpClientFactory = HttpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var productInfoResponse = await client.GetAsync("https://localhost:7080/api/ProductDetails/byproduct/" + productId);
            if (productInfoResponse.IsSuccessStatusCode)
            {
                var productInfoJsonData = await productInfoResponse.Content.ReadAsStringAsync();
                var productInfo = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(productInfoJsonData);

                if(productInfo != null)
                {
                    var productDetailInfo = new ProductInfoViewModel
                    {
                        ProductDescription = productInfo.ProductDescription,
                        ProductInfo = productInfo.ProductInfo
                    };

                     return View(productDetailInfo);
                }
               
            }

            return View(new ProductInfoViewModel());
        }
    }
}
