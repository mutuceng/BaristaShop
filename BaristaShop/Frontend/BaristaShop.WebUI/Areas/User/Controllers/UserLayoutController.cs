using BaristaShop.WebUI.Areas.User.Models;
using BaristaShop.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class UserLayoutController : Controller

    {
        private readonly IUserService _userService;

        public UserLayoutController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> _UserLayout()
        {

            return View();
        }
    }
}
