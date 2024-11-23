using BaristaShop.Basket.Dtos;
using BaristaShop.Basket.LoginServices;
using BaristaShop.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IBasketService _basketService;

        public BasketsController(ILoginService loginService, IBasketService basketService)
        {
            _loginService = loginService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var values = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Changes are saved");
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItemToBasket(BasketItemDto basketItemDto)
        {
            await _basketService.AddItemToBasketAsync(basketItemDto);
            return Ok("Item is added");
        }

        [HttpDelete("delete-item")]
        public async Task<IActionResult> DeleteItemFromBasket(BasketItemDto basketItemDto)
        {
            await _basketService.DeleteItemFromBasketAync(basketItemDto);
            return Ok("Item is Sucessfully deleted");
        }

        [HttpDelete("delete-basket")]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok("Whole basket sucessfully deleted");
        }

        [HttpDelete("empty-basket")]
        public async Task<IActionResult> EmptyBasket()
        {
            await _basketService.EmptyBasketAsync(_loginService.GetUserId);
            return Ok("Now basket is empty.");
        }
    }
}
