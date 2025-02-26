using BaristaShop.DtoLayer.Dtos.BasketDtos;
using System.Text.Json;

namespace BaristaShop.WebUI.Services.ApiServices.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task AddItemToBasketAsync(BasketItemDto basketItemDto)
        {
            // sepet varsa ve eklenmek istenen ürün sepette yoksa, ürünü sepete ekler.
            var values = await GetBasketAsync();
            if (values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    var existingItem = values.BasketItems.First(x => x.ProductId == basketItemDto.ProductId);
                    existingItem.Quantity += basketItemDto.Quantity;
                }
            }
            await SaveBasketAsync(values);
        }

        public async Task<bool> DeleteItemFromBasketAsync(string productId)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (deletedItem == null)
                return false; // Ürün zaten sepette yoksa, başarısız olduğu belirtilmeli.

            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasketAsync(values);
            return result;
        }

        public async Task EmptyBasketAsync()
        {
            var basketTotal = await GetBasketAsync();
            basketTotal.BasketItems.Clear();
            await SaveBasketAsync(basketTotal);
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("baskets", basketTotalDto);
        }

    }
}
