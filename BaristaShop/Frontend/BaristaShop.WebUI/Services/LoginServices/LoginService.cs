using System.Security.Claims;

namespace BaristaShop.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public LoginService(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
