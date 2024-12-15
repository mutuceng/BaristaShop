using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.VariantDtos
{
    public class UpdateVariantDto
    {
        public string VariantId { get; set; }
        public string VariantName { get; set; }

        public string CategoryId { get; set; }
    }
}
