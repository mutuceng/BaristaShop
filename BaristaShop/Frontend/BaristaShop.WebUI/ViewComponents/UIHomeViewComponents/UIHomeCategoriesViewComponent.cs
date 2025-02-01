using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaristaShop.WebUI.ViewComponents.UIHomeViewComponents
{
    public class UIHomeCategoriesViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIHomeCategoriesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();


            var categoryResponse = await client.GetAsync("https://localhost:7080/api/Categories");
            if (!categoryResponse.IsSuccessStatusCode)
            {
                return View();
            }

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            var productResponse = await client.GetAsync("https://localhost:7080/api/Products");
            if (!productResponse.IsSuccessStatusCode)
            {
                return View();
            }

            var productJson = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJson);

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
