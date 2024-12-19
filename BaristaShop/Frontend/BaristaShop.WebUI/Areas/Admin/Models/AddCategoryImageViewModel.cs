namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class AddCategoryImageViewModel
    {
        public string CategoryName { get; set; }
        public IFormFile CategoryImage { get; set; }
    }
}
