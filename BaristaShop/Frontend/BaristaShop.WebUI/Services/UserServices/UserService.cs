﻿using BaristaShop.WebUI.Models;

namespace BaristaShop.WebUI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("api/users/getuserinfo");
        }
    }
}
