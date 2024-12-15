using BaristaShop.Catalog.Dtos.VariantOptionDtos;

namespace BaristaShop.Catalog.Services.CategoryFeatureValueServices
{
    public interface IVariantOptionService
    {
        Task<List<ResultVariantOptionDto>> GetAllVariantOptionsAsync();
        Task CreateVariantOptionAsync(CreateVariantOptionDto categoryFeatureValueDto);
        Task UpdateVariantOptionAsync(UpdateVariantOptionDto categoryFeatureValueDto);
        Task DeleteVariantOptionAsync(string id);
        Task<GetByIdVariantOptionDto> GetByIdVariantOptionAsync(string id);
    }
}
