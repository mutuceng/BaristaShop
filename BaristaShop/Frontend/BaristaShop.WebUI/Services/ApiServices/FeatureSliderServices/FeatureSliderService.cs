using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace BaristaShop.WebUI.Services.ApiServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto featureSlider)
        {
            await _httpClient.PostAsJsonAsync("featuresliders", featureSlider);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders?id=" + id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();
            return values;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();
            return values;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto featureSlider)
        {
            await _httpClient.PutAsJsonAsync("featuresliders", featureSlider);
        }
    }
}
