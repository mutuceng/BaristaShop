using BaristaShop.DtoLayer.Dtos.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BaristaShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegisterDto userRegisterDto)
        {
            var userRegister = new UserRegisterDto
            {
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                UserName = userRegisterDto.UserName,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(userRegister);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:5001/api/Registers", stringContent);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
