namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class AddFeatureSlideImageViewModel
    {
        public string FeatureSliderTitle { get; set; }
        public string FeatureSliderDescription { get; set; }
        public IFormFile FeatureSliderImage { get; set; }
    }
}
