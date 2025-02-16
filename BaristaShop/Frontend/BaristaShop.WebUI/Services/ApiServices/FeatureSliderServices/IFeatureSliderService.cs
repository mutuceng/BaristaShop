using BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace BaristaShop.WebUI.Services.ApiServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto featureSlider);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto featureSlider);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
    }
}
