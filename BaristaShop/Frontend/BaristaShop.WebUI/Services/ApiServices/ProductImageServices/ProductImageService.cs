using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("ProductImages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductImages/{id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ProductImages");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();

            return values;
        }

        public async Task<GetProductImageByProductIdDto> GetProductImageByProductIdAsync(string productId)
        {
            var responseMessage = await _httpClient.GetAsync($"productimages/byproduct/{productId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetProductImageByProductIdDto>();

            try
            {
                responseMessage.EnsureSuccessStatusCode();
                return value;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                throw;
            }
        }
    }
}
