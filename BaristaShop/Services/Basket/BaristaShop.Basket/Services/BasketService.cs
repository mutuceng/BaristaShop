using BaristaShop.Basket.Dtos;
using BaristaShop.Basket.LoginServices;
using BaristaShop.Basket.Settings;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace BaristaShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly ILoginService _loginService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task AddItemToBasketAsync(BasketItemDto item)
        {
            var basket = await GetBasketAsync(_loginService.GetUserId);

            if (basket != null)
            {
                if (basket.BasketItems.Any(i => i.ProductId == item.ProductId))
                {
                    var existingItem = basket.BasketItems.First(i => i.ProductId == item.ProductId);
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    {
                        basket.BasketItems.Add(item);
                    }
                }
            }
            await SaveBasketAsync(basket);
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task DeleteItemFromBasketAync(BasketItemDto basketItemDto)
        {
            var basket = await GetBasketAsync(_loginService.GetUserId);
            if (basket != null)
            {
                var deletedItem = basket.BasketItems.FirstOrDefault(i => i.ProductId == basketItemDto.ProductId);
                if (deletedItem != null)
                {
                    basket.BasketItems.Remove(deletedItem);
                }
                else { return; }
            }
            else { return; }
        }

        public async Task EmptyBasketAsync(string userId)
        {
            var basket = await GetBasketAsync(userId);

            if(basket != null)
            {
                foreach(var item in basket.BasketItems)
                {
                    basket.BasketItems.Remove(item);
                }
            }
            else
            {
                return;
            }
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(userId);
            if (String.IsNullOrEmpty(basket))
            {
                // Boş bir sepet oluştur
                var emptyBasket = new BasketTotalDto
                {
                    UserId = userId,                     // Kullanıcı ID'sini ekle
                    DiscountCode = null,                 // İndirim kodu henüz yok
                    DiscountRate = 0,
                    BasketItems = new List<BasketItemDto>(), // Sepetteki ürünlerin listesi boş
                     
                };

                // Boş sepeti Redis'e kaydet
                var serializedBasket = JsonSerializer.Serialize(emptyBasket);
                await _redisService.GetDb().StringSetAsync(userId, serializedBasket);

                return emptyBasket;
            }
            else {
                return JsonSerializer.Deserialize<BasketTotalDto>(basket);
            }

        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
        //StringSetAsync >> Redis üzerinde bir anahtar-değer (key-value) çifti kaydeden bir yöntem
        // burada anathat basketTotalDto.UserId, değer ise JsonSerializer.Serialize(basketTotalDto
        // değer sepet bilgilerinin json formatına dönüştürülmüş hali
    }
}
