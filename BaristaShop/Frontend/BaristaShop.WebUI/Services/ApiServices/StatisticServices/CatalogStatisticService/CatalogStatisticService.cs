
namespace BaristaShop.WebUI.Services.ApiServices.StatisticServices.CatalogStatisticService
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;
        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<long> GetBrandCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCategoryCount()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMaxPriceProductName()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMinPriceProductName()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetProductCount()
        {
            throw new NotImplementedException();
        }
    }
}
