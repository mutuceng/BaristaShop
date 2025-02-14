using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;

namespace BaristaShop.WebUI.Services.ApiServices.ProductItemServices
{
    public interface IProductItemService
    {
        Task<List<ResultProductItemDto>> GetAllProductItemAsync();
        Task CreateProductItemAsync(CreateProductItemDto createProductItemDto);
        Task DeleteProductItemAsync(string id);
    }
}
