using BaristaShop.DtoLayer.Dtos.BasketDtos;

namespace BaristaShop.WebUI.Services.ApiServices.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task AddItemToBasketAsync(BasketItemDto basketItemDto);
        Task<bool> DeleteItemFromBasketAsync(string productId);
        Task EmptyBasketAsync();
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
    }
}
