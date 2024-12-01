using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Entities
{
    public enum ApprovalStatus
    {
        Pending,
        Denied,
        Approved
    }
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock{ get; set; }

        [BsonRepresentation(BsonType.String)]
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;

        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
