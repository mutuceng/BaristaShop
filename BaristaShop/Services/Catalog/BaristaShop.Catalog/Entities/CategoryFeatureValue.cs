using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class CategoryFeatureValue
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CategoryFeatureValueId { get; set; } 
        public string CategoryFeatureValueName { get; set; }


    }
}
