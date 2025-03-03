using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;

namespace BaristaShop.WebUI.Services.ApiServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;


        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateAddressDto createAddressDto)
        {
            await _httpClient.PostAsJsonAsync("Addresses", createAddressDto);
        }

        public async Task<List<GetAddressByUserId>> GetAddressByUserIdAsync(string id)
        {
            var addresses = await _httpClient.GetFromJsonAsync<List<GetAddressByUserId>>("http://localhost:5000/services/order/Addresses/AddressByUserId?id=" + id);
            return addresses ?? new List<GetAddressByUserId>();
        }
    }
}
