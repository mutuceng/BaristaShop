using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class CreateCategoryFeatureDto
    {
        public string CategoryFeatureName { get; set; }
        public List<string> CategoryFeatureValues { get; set; }
    }
}
