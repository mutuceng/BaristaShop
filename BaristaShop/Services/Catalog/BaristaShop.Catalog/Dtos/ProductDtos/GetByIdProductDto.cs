using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public bool ProductIsActive { get; set; }
        public bool ProductHasVariants { get; set; } = false;
        public string CategoryId { get; set; }
    }
}
