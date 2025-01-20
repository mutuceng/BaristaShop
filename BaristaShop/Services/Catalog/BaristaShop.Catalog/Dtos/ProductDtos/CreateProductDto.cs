using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public bool ProductIsActive { get; set; }
        public string CategoryId { get; set; }
    }
}
