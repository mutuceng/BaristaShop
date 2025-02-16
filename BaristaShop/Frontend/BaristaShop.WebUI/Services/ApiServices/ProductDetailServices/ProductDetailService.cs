using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("ProductDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductDetails/{id}");
        }

        public Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetProductDetailByProductIdDto> GetProductDetailByProductIdAsync(string productId)
        {
            var responseMessage = await _httpClient.GetAsync($"productdetails/byproduct/{productId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailByProductIdDto>();

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
