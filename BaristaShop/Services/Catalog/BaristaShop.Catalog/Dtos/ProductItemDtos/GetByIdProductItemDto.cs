namespace BaristaShop.Catalog.Dtos.ProductItemDtos
{
    public class GetByIdProductItemDto
    {
        public string ProductItemId { get; set; }
        public string ProductId { get; set; }
        public string SKU { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductPriceWithSale { get; set; }

    }
}
