using BaristaShop.Discount.Dtos.CouponDtos;

namespace BaristaShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<CouponResultDto>> GetAllCouponsAsync();
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
    }
}
