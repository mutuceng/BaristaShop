using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class CategoryFeature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryFeatureId { get; set; } 
        public string CategoryFeatureName { get; set; }
        public List<string> CategoryFeatureValues { get; set; } = new List<string>();

    }
}
