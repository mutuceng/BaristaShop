using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class ProductVariant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductVariantId { get; set; }

        public string ProductItemId { get; set; }

        public string VariantOptionId { get; set; }

        [BsonIgnore]
        public ProductItem ProductItem { get; set; }

        [BsonIgnore]
        public VariantOption VariantOption { get; set; }
        
    }
}
