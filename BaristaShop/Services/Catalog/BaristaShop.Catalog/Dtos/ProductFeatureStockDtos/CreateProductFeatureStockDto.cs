namespace BaristaShop.Catalog.Dtos.ProductFeatureStockDtos
{
    public class CreateProductFeatureStockDto
    {       
        public int ProductVariableStock { get; set; }
        public string ProductId { get; set; }
        public string CategoryFeatureValueId { get; set; }
    }
}
