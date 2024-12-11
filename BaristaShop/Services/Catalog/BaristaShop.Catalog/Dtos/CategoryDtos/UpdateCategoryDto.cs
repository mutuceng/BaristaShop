using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> Features { get; set; } = new List<string>();
    }
}
