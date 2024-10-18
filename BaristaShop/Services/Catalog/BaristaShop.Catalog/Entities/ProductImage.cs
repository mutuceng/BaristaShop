﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaristaShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
        public string Images5 { get; set; }

        
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
