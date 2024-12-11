namespace BaristaShop.Catalog.Dtos.ProductFeatureStockDtos
{
    public class UpdateProductVariantDto
    {
        public string ProductVariantId { get; set; }
        public int ProductVariantStock { get; set; }
        public decimal ProductVariantPrice { get; set; }

        public string ProductId { get; set; }
        public string CategoryFeatureValueId { get; set; }
    }
}
