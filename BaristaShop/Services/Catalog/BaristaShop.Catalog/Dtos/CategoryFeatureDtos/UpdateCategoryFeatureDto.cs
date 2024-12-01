namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class UpdateCategoryFeatureDto
    {
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
        public List<string> ValueOptions { get; set; } = new List<string>();
    }
}
