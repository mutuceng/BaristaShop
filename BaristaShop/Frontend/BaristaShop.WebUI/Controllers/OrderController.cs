using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.directory1 = "BaristaShop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";

            return View(); // Yeni adres oluşturmak için boş DTO gönderin
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
 

            var values = await _userService.GetUserInfo();
            createAddressDto.UserId = values.Id;

            await _orderAddressService.CreateOrderAddressAsync(createAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
