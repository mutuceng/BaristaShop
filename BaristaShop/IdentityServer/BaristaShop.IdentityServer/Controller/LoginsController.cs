using BaristaShop.IdentityServer.Dtos;
using BaristaShop.IdentityServer.Models;
using BaristaShop.IdentityServer.Tools.TokenGenerate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaristaShop.IdentityServer.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password,false , false);
            // isPersistent: false, lockoutOnFailure: false
            // ilki kullanıcı hatırlansın mı ikincisi yanlıs şifre sayacı 5 olduğunda hesap kilitlensin mi

            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (!result.Succeeded)
            {

                return BadRequest("Username or password is wrong");
            }

            GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
            model.UserName = userLoginDto.UserName;
            model.Id = user.Id;
            var token = JwtTokenGenerator.GenerateToken(model);

            return Ok(token);
        }
    }
}
