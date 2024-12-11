using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class GetByIdCategoryFeatureDto
    {
        public string CategoryFeatureId { get; set; }
        public string CategoryFeatureName { get; set; }
        public List<string> CategoryFeatureValues { get; set; } = new List<string>();
    }
}
