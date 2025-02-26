using BaristaShop.Basket.Dtos;

namespace BaristaShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userId);
        Task DeleteBasketAsync(string userId);
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);        

        // Burada sepete item ekleme çıkarma işlemleri daha sonra eklenecen
        // sepete ekleme için sepete erişim gerek sepete erişim için userid lazım
        // ama bu userid'yi addıtembasket fonskyionuna veremiyorum.
        // ilerde httpclient işin içine girdiğinde userdId vermeme gerek kalmıcak
    }
}
