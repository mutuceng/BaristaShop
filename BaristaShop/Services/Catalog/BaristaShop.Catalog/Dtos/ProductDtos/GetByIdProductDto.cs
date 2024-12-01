using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public ApprovalStatus Status { get; set; }

        public string CategoryId { get; set; }
    }
}
