using BaristaShop.DtoLayer.Dtos.IdentityDtos.LoginDtos;

namespace BaristaShop.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
