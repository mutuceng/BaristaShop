using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.OrderAddressServices;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IUserService userService, IOrderAddressService orderAddressService)
        {
            _userService = userService;
            _orderAddressService = orderAddressService;
        }

        [HttpGet]
        public IActionResult Index(decimal totalPrice, decimal? discountRate, decimal tax)
        {
            ViewBag.directory1 = "BaristaShop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";

            var model = new OrderPhaseViewModel();

            model.createAddressDto = new CreateAddressDto();
            model.orderDetailViewModel = new OrderDetailViewModel
            {
                DiscountRate = discountRate,
                TotalPrice = totalPrice,
                Tax = 10
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
 

            var values = await _userService.GetUserInfo();
            createAddressDto.UserId = values.Id;
            createAddressDto.Description = "aa";

            await _orderAddressService.CreateOrderAddressAsync(createAddressDto);

            return RedirectToAction("Index", "Order");
        }
    }
}
