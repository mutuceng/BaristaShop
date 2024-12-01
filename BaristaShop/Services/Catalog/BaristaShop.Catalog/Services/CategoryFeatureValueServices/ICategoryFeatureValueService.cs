using BaristaShop.Catalog.Dtos.CategoryFeatureValueDtos;

namespace BaristaShop.Catalog.Services.CategoryFeatureValueServices
{
    public interface ICategoryFeatureValueService
    {
        Task<List<ResultCategoryFeatureValueDto>> GetAllCategoryFeatureValueAsync();
        Task CreateCategoryFeatureValueAsync(CreateCategoryFeatureValueDto categoryFeatureValueDto);
        Task UpdateCategoryFeatureValueAsync(UpdateCategoryFeatureValueDto categoryFeatureValueDto);
        Task DeleteCategoryFeatureValueAsync(string id);
        Task<GetByIdCategoryFeatureValueDto> GetByIdCategoryFeatureValueAsync(string id);
    }
}
