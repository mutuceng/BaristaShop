namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class CreateCategoryFeatureDto
    {
        public string FeatureName { get; set; }
        public List<string> ValueOptions { get; set; } = new List<string>();
    }
}
