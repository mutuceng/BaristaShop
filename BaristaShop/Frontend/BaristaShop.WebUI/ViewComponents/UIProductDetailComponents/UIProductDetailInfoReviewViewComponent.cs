using BaristaShop.Catalog.Dtos.ProductDetailDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.ProductDetailServices;
using BaristaShop.WebUI.Services.ProductDataServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.UIProductDetailComponents
{
    public class UIProductDetailInfoReviewViewComponent:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public UIProductDetailInfoReviewViewComponent(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var productInfo = await _productDetailService.GetProductDetailByProductIdAsync(productId);

            if (productInfo != null)
            {
                var productDetailInfo = new ProductInfoViewModel
                {
                    ProductDescription = productInfo.ProductDescription,
                    ProductInfo = productInfo.ProductInfo
                };

                return View(productDetailInfo);
            }
               
            
            return View(new ProductInfoViewModel());
        }
    }
}
