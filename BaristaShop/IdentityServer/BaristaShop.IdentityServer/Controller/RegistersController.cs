using BaristaShop.IdentityServer.Dtos;
using BaristaShop.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace BaristaShop.IdentityServer.Controller
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Surname = userRegisterDto.Surname,
                PhoneNumber = userRegisterDto.Phone
            };

            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("User successfully registered");
            }
            else
            {
                return BadRequest(result.Errors.Select(e => e.Description)); ;
            }
        }
    }
}
