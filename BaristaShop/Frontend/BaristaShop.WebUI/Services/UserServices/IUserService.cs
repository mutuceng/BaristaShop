using BaristaShop.WebUI.Models;

namespace BaristaShop.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
