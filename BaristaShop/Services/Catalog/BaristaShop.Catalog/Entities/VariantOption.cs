using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class VariantOption
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VariantOptionId { get; set; } 
        public string VariantOptionValue { get; set; }


        public string VariantId { get; set; }   
        public Variant Variant { get; set; }
    }
}
