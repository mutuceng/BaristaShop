using BaristaShop.Discount.Context;
using BaristaShop.Discount.Dtos.CouponDtos;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BaristaShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,DiscountRate,IsActive,StartDate,FinishDate) values (@code,@discountRate,@isActive,@startDate,@finishDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@discountRate", createCouponDto.DiscountRate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@startDate", createCouponDto.StartDate);
            parameters.Add("@finishDate", createCouponDto.FinishDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<CouponResultDto>> GetAllCouponsAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<CouponResultDto>(query); // farklı olan kısım listolduğu için
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, DiscountRate=@discountRate, IsActive=@isActive, StartDate=@startDate, FinishDate=@finishDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@discountRate", updateCouponDto.DiscountRate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@startDate", updateCouponDto.StartDate);
            parameters.Add("@finishDate", updateCouponDto.FinishDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }



        public async Task<DiscountCodeDetailyByCodeDto> GetCodeDetailAsync(string code)
        {
            string query = "Select * from Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            // similar like getbyid
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<DiscountCodeDetailyByCodeDto>(query, parameters);
                return value;
            }
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            string query = "Select DiscountRate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
