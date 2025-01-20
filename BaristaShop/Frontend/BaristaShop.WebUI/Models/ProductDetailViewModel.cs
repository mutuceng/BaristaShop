namespace BaristaShop.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }


        public decimal ProductPrice { get; set; }
        public decimal ProductPriceWithSale { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }

    }
}
