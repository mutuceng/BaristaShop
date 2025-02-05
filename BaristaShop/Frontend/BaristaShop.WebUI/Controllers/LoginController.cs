using BaristaShop.DtoLayer.Dtos.IdentityDtos.LoginDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.IdentityServices;
using BaristaShop.WebUI.Services.LoginServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;


namespace BaristaShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            /* 
            // giriş yapan kullanıcı için manuel token alma işlemi
            var userLogin = new UserLoginDto
            {
                UserName = userLoginDto.UserName,
                Password = userLoginDto.Password
            };
            // üstteki bi tık gereksiz hatta da neysessss
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(userLogin);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:5001/api/Logins", stringContent);

            if (response.Result.IsSuccessStatusCode)
            {
                var responseJsonData = response.Result.Content.ReadAsStringAsync().Result;


                // newtonsoft'tan mı system.text'ten mi deserialize edilecek onun kararını vermesi için belirttik
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(responseJsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("baristashoptoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpiredDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                        var id = _loginService.GetUserId;

                        return RedirectToAction("Index", "Home");

                    }
                }
                
            } */

            return View();
        }




        // Farklı bir yöntemle token alma işlemi
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.UserName = "mutu";
            signInDto.Password = "mutu123D!";


            await _identityService.SignIn(signInDto);

            return RedirectToAction("Index", "Test");
        }
    }
}
