using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products?id=" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();

            return values;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return value;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("products", updateProductDto);
        }
    }
}
