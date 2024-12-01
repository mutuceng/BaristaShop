using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;

namespace BaristaShop.Catalog.Services.ProductFeatureStockServices
{
    public interface IProductFeatureStockService
    {
        Task <List<ResultProductFeatureStockDto>> GetAllProductFeatureStockAsync();
        Task<GetByIdProductFeatureStockDto> GetByIdProductFeatureStockAsync(string id);
        Task CreateProductFeatureStockAsync(CreateProductFeatureStockDto productFeatureStockDto);
        Task DeleteProductFeatureStockAsync(string id);
        Task UpdateProductFeatureStockAsync(UpdateProductFeatureStockDto productFeatureStockDto);
    }
}
