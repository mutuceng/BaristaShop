using BaristaShop.DtoLayer.Dtos.OrderDtos.AddressDtos;

namespace BaristaShop.WebUI.Models
{
    public class OrderPhaseViewModel
    {
        public CreateAddressDto createAddressDto { get; set; }

        public OrderDetailViewModel orderDetailViewModel { get; set; }
    }
}
