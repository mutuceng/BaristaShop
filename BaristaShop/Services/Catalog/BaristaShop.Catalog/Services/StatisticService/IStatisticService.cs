namespace BaristaShop.Catalog.Services.StatisticService
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
