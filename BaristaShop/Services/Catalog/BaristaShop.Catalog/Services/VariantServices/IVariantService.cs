using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Dtos.VariantOptionDtos;

namespace BaristaShop.Catalog.Services.CategoryFeatureServices
{
    public interface IVariantService
    {
        Task<List<ResultVariantDto>> GetAllVariantsAsync();
        Task CreateVariantAsync(CreateVariantDto createCategoryFeatureDto);
        Task UpdateVariantAsync(UpdateVariantDto updateCategoryFeatureDto);
        Task DeleteVariantAsync(string id);
        Task<GetByIdVariantDto> GetByIdVariantAsync(string id);
        Task<List<GetByIdVariantOptionDto>> GetByIdsAsync(List<string> ids);   
    }
}
