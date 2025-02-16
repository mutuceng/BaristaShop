using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;

namespace BaristaShop.WebUI.Services.ApiServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto specialOffer)
        {
            await _httpClient.PostAsJsonAsync("SpecialOffers", specialOffer);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"SpecialOffers/{id}");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var response = await _httpClient.GetAsync("specialoffers");
            var values = await response.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
            return values;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var response = await _httpClient.GetAsync("specialoffers/" + id);
            var value = await response.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();

            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto specialOffer)
        {
            await _httpClient.PutAsJsonAsync("SpecialOffers", specialOffer);
        }
    }
}
