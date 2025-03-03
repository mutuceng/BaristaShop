using BaristaShop.DtoLayer.Dtos.BasketDtos;

namespace BaristaShop.WebUI.Models
{
    public class OrderSummaryViewModel
    {
        public List<BasketItemDto>? BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal? TotalPriceWithDiscount { get; set; }
        public decimal TotalPriceWithTax { get; set; }

    }
}
