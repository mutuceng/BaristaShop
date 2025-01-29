using System;

namespace BaristaShop.IdentityServer.Tools.TokenGenerate
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expiredDate)
        {
            Token = token;
            ExpiredDate = expiredDate;
        }

        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
