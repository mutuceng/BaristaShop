using BaristaShop.WebUI.Models;

namespace BaristaShop.WebUI.Services.ProductDataServices
{
    public interface IProductDataService
    {
        Task<ProductsWithAllAttributesViewModel> GetProductDataAsync(string productId);
        Task<List<ProductsWithAllAttributesViewModel>> GetAllProductDataAsync();

        Task<List<ProductPreviewViewModel>> GetAllProductPrevDataAsync();

        Task<List<ProductPreviewViewModel>> GetAllProductPrevDataByCategoryIdAsync(string categoryId);


    }
}
