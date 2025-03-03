using BaristaShop.DtoLayer.Dtos.BasketDtos;

namespace BaristaShop.WebUI.Models
{
    public class OrderDetailViewModel
    {
        public List<BasketItemDto>? BasketItems;
        public decimal TotalPrice { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal Tax { get; set; }

    }
}
