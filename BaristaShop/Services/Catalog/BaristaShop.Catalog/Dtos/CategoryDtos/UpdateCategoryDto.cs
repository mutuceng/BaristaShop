using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}
