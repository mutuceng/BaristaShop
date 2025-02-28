using BaristaShop.DtoLayer.Dtos.DiscountDtos;

namespace BaristaShop.WebUI.Services.ApiServices.DiscountServices
{
    public interface IDiscountService
    {
        Task<DiscountCodeDetailyByCodeDto> GetCodeDetailAsync(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
