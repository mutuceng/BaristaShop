
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task DeleteProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<GetProductImageByProductIdDto> GetProductImageByProductIdAsync(string productId);
    }
}
