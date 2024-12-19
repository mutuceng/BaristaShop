using BaristaShop.Catalog.Dtos.AboutUsDtos;
using BaristaShop.Catalog.Dtos.CategoryDtos;

namespace BaristaShop.Catalog.Services.AboutUsServices
{
    public interface IAboutUsService
    {
        Task<ResultAboutUsDto> GetAboutUsAsync();
        Task CreateAboutUsAsync(CreateAboutUsDto createAboutUsDto);
        Task UpdateAboutUsAsync(UpdateAboutUsDto updateAboutUsDto);

    }
}
