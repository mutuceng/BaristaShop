using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;
using System.Collections.Specialized;

namespace BaristaShop.WebUI.Services.ApiServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        // Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateOrderAddressAsync(CreateAddressDto createAddressDto);
        Task<List<GetAddressByUserId>> GetAddressByUserIdAsync(String id);

        //    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //    Task DeleteAboutAsync(string id);
        //    Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
