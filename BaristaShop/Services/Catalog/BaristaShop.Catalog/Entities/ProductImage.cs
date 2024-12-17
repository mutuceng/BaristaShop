﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }


        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
