namespace BaristaShop.Catalog.Dtos.ProductItemDtos
{
    public class CreateProductItemDto
    {
        public string ProductId { get; set; }
        public string SKU { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
