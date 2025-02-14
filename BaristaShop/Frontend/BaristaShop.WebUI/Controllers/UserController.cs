using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();
            return View(user);
        }
    }
}
