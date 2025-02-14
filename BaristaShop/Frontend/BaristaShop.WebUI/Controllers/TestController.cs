using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using BaristaShop.WebUI.Services.ApiServices.CategoryServices;


namespace BaristaShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            // ziyaretçi için token alma yöntemi // deneme
            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id", "BaristaShopVisitorId"},
                        {"client_secret","baristashopsecret" },
                        {"grant_type", "client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);

                        token = tokenResponse["access_token"]?.ToString();
                    }
                }
            }

            if(string.IsNullOrEmpty(token))
            {
                return View();
            }

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseCategory = await client.GetAsync("https://localhost:7080/api/Categories");
            if(responseCategory.IsSuccessStatusCode)
            {
                var jsonData = await responseCategory.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        
                return View(categories);
            }

            return View();


            // Burada güzelce çalıştı ziyaretçi giriş yapmadan görebiliyor ancak bu kodları sürekli tekrar edicez
            // Bunun için Ocelet Gateway kullanıcaz ve işlemleri azaltarak daha sağlıklı bir yapı elde edicez.
        }


        public async Task<IActionResult> Deneme()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
