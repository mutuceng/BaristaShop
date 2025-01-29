using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaristaShop.IdentityServer.Tools.TokenGenerate
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(model.Id))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            }

            if (!string.IsNullOrEmpty(model.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiredDate,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expiredDate);

        }
    }
}
