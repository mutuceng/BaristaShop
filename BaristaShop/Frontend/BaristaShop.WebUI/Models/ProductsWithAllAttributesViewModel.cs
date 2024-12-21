namespace BaristaShop.WebUI.Models
{
    public class ProductsWithAllAttributesViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public bool ProductIsActive { get; set; }
        public string CategoryId { get; set; }

        public string SKU { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductPriceWithSale { get; set; }

        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }


    }
}
