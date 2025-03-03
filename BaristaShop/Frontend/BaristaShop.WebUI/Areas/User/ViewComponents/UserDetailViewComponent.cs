using BaristaShop.WebUI.Areas.User.Models;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.User.ViewComponents
{
    public class UserDetailViewComponent:ViewComponent
    {
        private readonly IUserService _userService;

        public UserDetailViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userinfo = await _userService.GetUserInfo();

            var userDetailViewModel = new UserDetailViewModel
            {
                UserId = userinfo.Id,
                UserName = userinfo.Username,
                Name = userinfo.Name,
                SurName = userinfo.Surname,
                Email = userinfo.Email
            };
            return View(userDetailViewModel);
        }
    }
}
