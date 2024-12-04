using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class CategoryFeature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryFeatureId { get; set; } = ObjectId.GenerateNewId().ToString();
        public string CategoryFeatureName { get; set; }
        public List<CategoryFeatureValue> FeatureValues { get; set; } = new List<CategoryFeatureValue>();

    }
}
