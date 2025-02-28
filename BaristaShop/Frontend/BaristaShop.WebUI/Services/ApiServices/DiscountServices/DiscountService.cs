using BaristaShop.DtoLayer.Dtos.DiscountDtos;

namespace BaristaShop.WebUI.Services.ApiServices.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiscountCodeDetailyByCodeDto> GetCodeDetailAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/GetCodeDetailByCode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<DiscountCodeDetailyByCodeDto>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetDiscountCouponCountRate?code=");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
