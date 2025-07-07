using BaristaShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;
using BaristaShop.WebUI.Services.ApiServices.OrderOrderingServices;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();

            var values = await _orderingService.GetOrderingsByUserIdAsync(user.Id);

            var myOrdergins = new List<GetOrderingsByUserIdDto>();

            foreach (var value in values)
            {
                myOrdergins.Add(new GetOrderingsByUserIdDto
                {
                    OrderDate = value.OrderDate,
                    TotalPrice = value.TotalPrice,
                    AddressId = value.AddressId,
                    UserId = value.UserId
                });
            }

            return View(values);
        }
    }
}
