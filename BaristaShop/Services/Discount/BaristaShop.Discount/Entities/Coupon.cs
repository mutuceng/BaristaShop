namespace BaristaShop.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public  string Code { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
