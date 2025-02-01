using BaristaShop.Catalog.Dtos.AboutUsDtos;
using BaristaShop.Catalog.Services.AboutUsServices;
using BaristaShop.Catalog.Services.SpecifalOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService AboutUsService)
        {
            _aboutUsService = AboutUsService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutUsList()
        {
            var values = await _aboutUsService.GetAboutUsAsync();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(CreateAboutUsDto createAboutUsDto)
        {
            await _aboutUsService.CreateAboutUsAsync(createAboutUsDto);
            return Ok("Successfully added");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
        {
            await _aboutUsService.UpdateAboutUsAsync(updateAboutUsDto);
            return Ok("Successfully updated");
        }
    }
}
