using BaristaShop.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Dtos.ProductFeatureStockDtos
{
    public class CreateProductVariantDto
    {
        public string ProductItemId { get; set; }

        public string VariantOptionId { get; set; }

    }
}
