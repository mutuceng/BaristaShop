using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.CategoryServices;
using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaristaShop.WebUI.ViewComponents.UIHomeViewComponents
{
    public class UIHomeCategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public UIHomeCategoriesViewComponent(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();

            var products = await _productService.GetAllProductAsync();

            var categoryProductCount = categories.Select(category => new CategoriesWithProductCountViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                // CategoryImage = category.CategoryImage, // Varsayalım ki kategori resimleri mevcut
                ProductCount = products.Count(product => product.CategoryId == category.CategoryId)
            }).ToList();

            // 4. Kategorileri ürün sayısına göre sırala (azalan sırayla)
            var sortedCategories = categoryProductCount.OrderByDescending(c => c.ProductCount).Take(12).ToList();

            // 5. Kategorileri View'e gönder
            return View(sortedCategories);
        
        }
    }
}
