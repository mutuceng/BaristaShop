using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;

        public string CategoryId { get; set; }
    }
}
