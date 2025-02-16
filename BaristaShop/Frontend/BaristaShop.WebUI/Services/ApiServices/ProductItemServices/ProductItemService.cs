using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using BaristaShop.WebUI.Services.ApiServices.ProductItemServices;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;


namespace BaristaShop.WebUI.Services.ApiServices.ProductItemServices
{
    public class ProductItemService : IProductItemService
    {

        private readonly HttpClient _httpClient;
        private readonly IProductService _productService;

        public ProductItemService(HttpClient httpClient, IProductService productService)
        {
            _httpClient = httpClient;
            _productService = productService;
        }

        public async Task CreateProductItemAsync(CreateProductItemDto productItem)
        {
            await _httpClient.PostAsJsonAsync("productitems", productItem);
        }

        public async Task DeleteProductItemAsync(string id)
        {
            await _httpClient.DeleteAsync("productitems?id=" + id);
        }

        public async Task<List<ResultProductItemDto>> GetAllProductItemAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productitems");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductItemDto>>();
            return values;
        }

        public async Task<GetProductItemByProductIdDto> GetProductItemByProductIdAsync(string productId)
        {
            var responseMessage = await _httpClient.GetAsync($"productitems/byproduct/{productId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetProductItemByProductIdDto>();

            try
            {
                responseMessage.EnsureSuccessStatusCode(); // HTTP isteği başarısız olursa Exception fırlatır.
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
