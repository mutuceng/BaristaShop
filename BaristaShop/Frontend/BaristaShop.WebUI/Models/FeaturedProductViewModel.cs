﻿namespace BaristaShop.WebUI.Models
{
    public class FeaturedProductViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public bool ProductIsActive { get; set; }

        public decimal ProductPrice { get; set; }
        public decimal ProductPriceWithSale { get; set; }

        public string Image1 { get; set; }
    }
}
