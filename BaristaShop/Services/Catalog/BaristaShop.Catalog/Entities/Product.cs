using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public bool ProductIsActive { get; set; } = true;
        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

        
    }
}
