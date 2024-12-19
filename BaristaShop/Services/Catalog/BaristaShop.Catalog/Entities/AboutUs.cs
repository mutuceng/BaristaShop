using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class AboutUs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string AboutInfo { get; set; }
        public string AboutEmail { get; set; }
        public string AboutPhone { get; set; }
    }
}
