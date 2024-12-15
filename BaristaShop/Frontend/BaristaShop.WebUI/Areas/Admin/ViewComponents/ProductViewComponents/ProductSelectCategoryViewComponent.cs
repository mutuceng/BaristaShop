using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson.IO;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace BaristaShop.WebUI.Areas.Admin.ViewComponents.ProductViewComponents
{
    [Area("Admin")]
    public class ProductSelectCategoryViewComponent:ViewComponent
    {
       
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductSelectCategoryViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categories = (from x in values
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.CategoryName,
                                                                  Value = x.CategoryId
                                                              }).ToList();

                ViewBag.Categories = categories;
            }
                
            return View();
        }
    }
}
