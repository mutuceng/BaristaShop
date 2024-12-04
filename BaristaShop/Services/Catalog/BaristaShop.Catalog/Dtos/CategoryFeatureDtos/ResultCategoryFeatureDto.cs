using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class ResultCategoryFeatureDto
    {
        public string CategoryFeatureId { get; set; }
        public string CategoryFeatureName { get; set; }
        public List<CategoryFeatureValue> FeatureValues { get; set; } = new List<CategoryFeatureValue>();
    }
}
