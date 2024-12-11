using BaristaShop.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Dtos.ProductFeatureStockDtos
{
    public class CreateProductVariantDto
    {
        public int ProductVariantStock { get; set; }
        public decimal ProductVariantPrice { get; set; }

        public string ProductId { get; set; }
        public string CategoryFeatureValueId { get; set; }
      
    }
}
