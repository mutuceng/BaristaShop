using BaristaShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;

namespace BaristaShop.WebUI.Services.ApiServices.OrderOrderingServices
{
    public interface IOrderingService
    {
        Task CreateOrderingAsync(CreateOrderingDto createOrderingDto);
        Task<List<GetOrderingsByUserIdDto>> GetOrderingsByUserIdAsync(string id);

    }
}
