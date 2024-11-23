namespace BaristaShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
        // null safety kullanımı aşağıda

        public string GetUserId
        {
            get
            {
                // HttpContext ve User objelerinin null olup olmadığını kontrol et
                var user = _httpContextAccessor.HttpContext?.User;
                if (user != null)
                {
                    var userIdClaim = user.FindFirst("sub");
                    if (userIdClaim != null)
                    {
                        return userIdClaim.Value; // "sub" claim varsa döndür
                    }
                }

                // "sub" claim yoksa veya oturum açılmamışsa, null veya default bir değer döndür
                return null; 
            }
        }
    }
}
