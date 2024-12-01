using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class CategoryFeature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
        public List<CategoryFeatureValue> FeatureValues { get; set; } = new List<CategoryFeatureValue>();

    }
}
