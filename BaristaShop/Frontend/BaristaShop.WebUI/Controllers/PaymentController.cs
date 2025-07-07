using BaristaShop.DtoLayer.Dtos.BasketDtos;
using BaristaShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using BaristaShop.WebUI.Services.ApiServices.OrderOrderingServices;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IBasketService basketService, IOrderingService orderingService, IUserService userService, ILogger<PaymentController> logger)
        {
            _basketService = basketService;
            _orderingService = orderingService;
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int AddressId, decimal DiscountRate)
        {
            var basket = await _basketService.GetBasketAsync();
            
            var ordering = new OrderingViewModel
            {
                AddressId = AddressId,
                DiscountRate = DiscountRate
            };


            return View(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> Ordering(OrderingViewModel orderingViewModel) 
        {
            var user = await _userService.GetUserInfo();
            var basket = await _basketService.GetBasketAsync();

            var createOrderingDto = new CreateOrderingDto
            {
                UserId = user.Id,
                AddressId = orderingViewModel.AddressId,
                OrderDate = DateTime.Now,
                TotalPrice = basket.TotalPrice + basket.TotalPrice * 10/100,
            };


            if (orderingViewModel.DiscountRate !=0 && orderingViewModel.DiscountRate != null)
            {
                createOrderingDto.TotalPrice = createOrderingDto.TotalPrice - (createOrderingDto.TotalPrice * orderingViewModel.DiscountRate / 100);
            }

            try
            {
                await _orderingService.CreateOrderingAsync(createOrderingDto);
                await _basketService.EmptyBasketAsync(); // Sadece sipariş başarılı olursa çalışır
            }
            catch (Exception ex)
            {
                // Hata loglanabilir veya kullanıcıya bilgi verilebilir
                _logger.LogError(ex, "Ordering işlemi sırasında hata oluştu.");
                throw; // Hatanın yukarıya fırlatılması gerekiyorsa
            }



            return RedirectToAction("Index", "MyOrder", new {area = "User"});
        }
    }
}
