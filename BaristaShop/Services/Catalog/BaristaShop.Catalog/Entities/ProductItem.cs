using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class ProductItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductItemId { get; set; }
        public string ProductId { get; set; }
        public string SKU { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }


    }
}
