using BaristaShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;

namespace BaristaShop.WebUI.Services.ApiServices.OrderOrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;
        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderingAsync(CreateOrderingDto createOrderingDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderingDto>("http://localhost:7082/api/Orderings", createOrderingDto);
        }

        public async Task<List<GetOrderingsByUserIdDto>> GetOrderingsByUserIdAsync(string id)
        {
            var addresses = await _httpClient.GetFromJsonAsync<List<GetOrderingsByUserIdDto>>("http://localhost:5000/services/order/Orderings/OrderingsByUserId?id=" + id);
            return addresses ?? new List<GetOrderingsByUserIdDto>();
        }
    }
}
