using BaristaShop.Catalog.Dtos.ProductItemDtos;

namespace BaristaShop.Catalog.Services.ProductItemServices
{
    public interface IProductItemService
    {
        Task<List<ResultProductItemDto>> GetAllProductItemAsync();
        Task CreateProductItemAsync(CreateProductItemDto product);
        Task UpdateProductItemAsync(UpdateProductItemDto product);
        Task DeleteProductItemAsync(string id);
        Task<GetByIdProductItemDto> GetByIdProductItemAsync(string id);
        Task<GetProductItemByProductIdDto> GetProductItemByProductIdAsync(string productId);
    }
}
