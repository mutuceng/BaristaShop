namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class AddSpecialOfferImageViewModel
    {
        public string SpecialOfferTitle { get; set; }
        public string SpecialOfferSubTitle { get; set; }
        public IFormFile SpecialOfferImage { get; set; }
    }
}
