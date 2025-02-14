using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;

namespace BaristaShop.WebUI.Services.ApiServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        // burada ocelota uygun formatta yeniden yazıyoruz ki 
        // her seferinde tek bir porttan istek gönderilsin
        // programcs'te confige de bak

        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {

            // var response = await client.PostAsync("https://localhost:7080/api/Categories", content);
            await _httpClient.PostAsJsonAsync("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);

            // await _httpClient.DeleteAsync($"categories/{id}"); burası kritik üstteki gibi olcak
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            /*
                var response = await _httpClient.GetAsync("https://localhost:7080/api/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                    return View(values);
                }

                iki farklı yol ikisi de okey. 
            */
            var responseMessage = await _httpClient.GetAsync("categories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();

            return values;
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();

            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
