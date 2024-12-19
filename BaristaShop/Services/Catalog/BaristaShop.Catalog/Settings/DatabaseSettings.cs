namespace BaristaShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }

        public string ProductCollectionName { get; set; }
        public string ProductItemCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }

        public string VariantCollectionName { get; set; }
        public string VariantOptionCollectionName { get; set; }
        public string ProductVariantCollectionName { get; set; }

        public string FeatureSliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }

        public string AboutUsCollectionName { get; set; }


        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
