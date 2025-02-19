﻿using BaristaShop.WebUI.Models;

namespace BaristaShop.WebUI.Services.ProductDataServices
{
    public interface IProductDataService
    {
        Task<ProductDetailViewModel> GetProductDataAsync(string productId);
        Task<List<ProductsWithAllAttributesViewModel>> GetAllProductDataAsync();

        Task<List<ProductPreviewViewModel>> GetAllProductPrevDataAsync();

        Task<List<ProductPreviewViewModel>> GetAllProductPrevDataByCategoryIdAsync(string categoryId);


    }
}
