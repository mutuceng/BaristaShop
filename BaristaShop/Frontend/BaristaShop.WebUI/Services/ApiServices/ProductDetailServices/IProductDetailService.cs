
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<ResultProductDetailDto> GetProductDetailByProductIdAsync(string productId);
    }
}
