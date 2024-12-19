using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BaristaShop.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string SpecialOfferTitle { get; set; }
        public string SpecialOfferSubTitle { get; set; }
        public string SpecialOfferImage { get; set; }
    }
}
