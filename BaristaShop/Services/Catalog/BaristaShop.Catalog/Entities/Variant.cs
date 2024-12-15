using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class Variant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VariantId { get; set; } 
        public string VariantName { get; set; }

        public string CategoryId {  get; set; }
        public Category Category { get; set; }

    }
}
