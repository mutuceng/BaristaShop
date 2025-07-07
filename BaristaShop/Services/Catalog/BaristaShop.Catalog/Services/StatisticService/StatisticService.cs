
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.StatisticService
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        // private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            // _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        }
        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "ProductDetail" }, // ProductDetail koleksiyonuyla join yapılıyor
                    { "localField", "ProductId" }, // Product içindeki eşleşecek alan
                    { "foreignField", "ProductId" }, // ProductDetail içindeki eşleşecek alan
                    { "as", "ProductDetails" } // Sonuç, "ProductDetails" adlı dizi olarak eklenecek
                }),
                new BsonDocument("$unwind", "$ProductDetails"), // Diziyi açarak birebir eşleşme sağlıyoruz
                new BsonDocument("$sort", new BsonDocument("ProductDetails.ProductPrice", -1)), // Fiyata göre azalan sıralama
                new BsonDocument("$limit", 1), // En yüksek fiyatlı ürünü seçiyoruz
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 }, // _id alanını hariç tut
                    { "ProductName", 1 } // Sadece ProductName getir
                })
             };

            var product = await _productCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();

            return product?["ProductName"].AsString ?? "Ürün bulunamadı";
        }

        public async Task<string> GetMinPriceProductName()
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "ProductItems" },
                    { "localField", "ProductId" }, // Ensure this matches the correct field
                    { "foreignField", "ProductId" },
                    { "as", "ProductItem" }
                }),
                new BsonDocument("$unwind", "$ProductItem"),
                new BsonDocument("$sort", new BsonDocument("ProductItem.ProductPrice", 1)),
                new BsonDocument("$limit", 1),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "ProductName", 1 }
                })
            };

            var product = await _productCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();

            return product != null && product.Contains("ProductName") ? product["ProductName"].AsString : "Ürün bulunamadı";
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new[]
            {
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "ProductItem" },
            { "localField", "_id" },  // Eğer ana koleksiyonda _id kullanıyorsan burayı "_id" yapmalısın
            { "foreignField", "ProductId" },
            { "as", "ProductItems" }
        }),
        new BsonDocument("$unwind", "$ProductItems"),
        new BsonDocument("$group", new BsonDocument
        {
            { "_id", BsonNull.Value },
            { "AveragePrice", new BsonDocument("$avg", new BsonString("$ProductItems.ProductPrice")) }
        })
    };

            var result = await _productCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();

            return result != null && result.Contains("AveragePrice") ? result["AveragePrice"].ToDecimal() : 0.0m;
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
