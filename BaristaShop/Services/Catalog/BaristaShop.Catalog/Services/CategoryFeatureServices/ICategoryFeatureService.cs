using BaristaShop.Catalog.Dtos.CategoryFeatureDtos;

namespace BaristaShop.Catalog.Services.CategoryFeatureServices
{
    public interface ICategoryFeatureService
    {
        Task<List<ResultCategoryFeatureDto>> GetAllFeaturesAsync();
        Task CreateCategoryFeatureAsync(CreateCategoryFeatureDto createCategoryFeatureDto);
        Task UpdateCategoryFeatureAsync(UpdateCategoryFeatureDto updateCategoryFeatureDto);
        Task DeleteCategoryFeatureAsync(string id);
        Task<GetByIdCategoryFeatureDto> GetByIdCategoryFeatureAsync(string id);
    }
}
