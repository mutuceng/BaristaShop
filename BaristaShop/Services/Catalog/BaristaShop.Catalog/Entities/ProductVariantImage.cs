using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class ProductVariantImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductVariantImageId { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
        public string Images5 { get; set; }


        public string ProductVariantId { get; set; }

        [BsonIgnore]
        public ProductVariant ProductVariant { get; set; }
    }
}
