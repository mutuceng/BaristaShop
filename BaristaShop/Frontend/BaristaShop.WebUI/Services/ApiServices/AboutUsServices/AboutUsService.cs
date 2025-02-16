using BaristaShop.DtoLayer.Dtos.CatalogDtos.AboutUsDtos;

namespace BaristaShop.WebUI.Services.ApiServices.AboutUsServices
{
    public class AboutUsService : IAboutUsService
    {
        private readonly HttpClient _httpClient;

        public AboutUsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutUsAsync(CreateAboutUsDto createAboutUsDto)
        {
            await _httpClient.PostAsJsonAsync("aboutus", createAboutUsDto);
        }

        public async Task<ResultAboutUsDto> GetAboutUsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("aboutus");
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultAboutUsDto>();
            return values;
        }

        public async Task UpdateAboutUsAsync(UpdateAboutUsDto updateAboutUsDto)
        {
            await _httpClient.PutAsJsonAsync("aboutus", updateAboutUsDto);
        }
    }
}
