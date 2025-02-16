using BaristaShop.DtoLayer.Dtos.CatalogDtos.AboutUsDtos;

namespace BaristaShop.WebUI.Services.ApiServices.AboutUsServices
{
    public interface IAboutUsService
    {
        Task<ResultAboutUsDto> GetAboutUsAsync();
        Task CreateAboutUsAsync(CreateAboutUsDto createAboutUsDto);
        Task UpdateAboutUsAsync(UpdateAboutUsDto updateAboutUsDto);
    }
}
