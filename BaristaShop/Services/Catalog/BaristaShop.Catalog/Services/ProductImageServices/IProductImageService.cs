using BaristaShop.Catalog.Dtos.ProductImageDtos;

namespace BaristaShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
