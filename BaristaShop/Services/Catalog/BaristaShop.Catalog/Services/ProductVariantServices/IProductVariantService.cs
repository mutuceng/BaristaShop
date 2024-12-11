using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;

namespace BaristaShop.Catalog.Services.ProductFeatureStockServices
{
    public interface IProductVariantService
    {
        Task <List<ResultProductVariantDto>> GetAllProductVariantAsync();
        Task<GetByIdProductVariantDto> GetByIdProductVariantAsync(string id);
        Task CreateProductVariantAsync(CreateProductVariantDto productFeatureStockDto);
        Task DeleteProductVariantAsync(string id);
        Task UpdateProductVariantAsync(UpdateProductVariantDto productFeatureStockDto);
    }
}
