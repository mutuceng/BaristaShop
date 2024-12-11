using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class ProductVariant
    {
        public string ProductVariantId { get; set; }
        public int ProductVariantStock { get; set; }
        public decimal ProductVariantPrice { get; set; }

        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }

        [BsonIgnore]
        public string CategoryFeatureValueId { get; set; }
        public CategoryFeatureValue CategoryFeatureValue { get; set; }
        
    }
}
