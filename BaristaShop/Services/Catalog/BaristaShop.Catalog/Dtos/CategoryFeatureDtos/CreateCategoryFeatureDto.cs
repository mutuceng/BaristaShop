using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class CreateCategoryFeatureDto
    {
        public string FeatureName { get; set; }
        public List<CategoryFeatureValue> FeatureValues { get; set; } = new List<CategoryFeatureValue>();
    }
}
