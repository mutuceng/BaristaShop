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

        public BasketService(RedisService redisService, ILoginService loginService)
        {
            _redisService = redisService;
            //loginservice'den userid alma işini kaldırdık cunku userid artık token'dan gelicek.
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {

            var existingBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existingBasket);

            // old way
            /*
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
            else
            {
                return JsonSerializer.Deserialize<BasketTotalDto>(basket);
            }
            */
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
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
