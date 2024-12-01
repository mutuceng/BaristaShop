namespace BaristaShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string CategoryFeatureCollectionName { get; set; }
        public string CategoryFeatureValueCollectionName { get; set; }

        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductFeatureStockCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
