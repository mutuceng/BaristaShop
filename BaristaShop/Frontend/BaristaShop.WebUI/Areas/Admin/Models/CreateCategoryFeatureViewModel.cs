namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class CreateCategoryFeatureViewModel
    {
        public string CategoryFeatureName { get; set; } = null!;
        public List<string> CategoryFeatureValues { get; set; } = new List<string>();
    }
}
