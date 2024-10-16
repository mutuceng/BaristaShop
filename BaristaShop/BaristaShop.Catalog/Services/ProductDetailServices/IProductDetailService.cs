using BaristaShop.Catalog.Dtos.ProductDetailDtos;

namespace BaristaShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailsAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailsAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailsAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
