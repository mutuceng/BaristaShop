using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.VariantDtos
{
    public class CreateVariantDto
    {
        public string VariantName { get; set; }

        public string CategoryId { get; set; }
    }
}
