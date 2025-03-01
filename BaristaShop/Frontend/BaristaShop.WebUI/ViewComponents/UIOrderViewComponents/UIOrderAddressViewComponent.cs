using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;
using BaristaShop.WebUI.Services.ApiServices.OrderAddressServices;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIOrderViewComponents
{
    public class UIOrderAddressViewComponent:ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public UIOrderAddressViewComponent(IUserService userService, IOrderAddressService orderAddressService)
        {
            _userService = userService;
            _orderAddressService = orderAddressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await _userService.GetUserInfo();
            var address = await _orderAddressService.GetAddressByUserIdAsync(userInfo.Id); 

            return View(address); 
        }
    }
}
