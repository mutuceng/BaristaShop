using System.Security.Claims;

namespace BaristaShop.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpContext _httpContext;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string GetUserId => _httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
