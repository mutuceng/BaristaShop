using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.ProductFeatureStockServices
{
    public class ProductFeatureStockService : IProductFeatureStockService
    {
        IMongoCollection<ProductFeatureStock> _stockCollection;
        IMapper _mapper;

        public ProductFeatureStockService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            var stockCollection = database.GetCollection<ProductFeatureStock>(_databaseSettings.ProductFeatureStockCollectionName);

            _mapper = mapper;
        }

        public async Task CreateProductFeatureStockAsync(CreateProductFeatureStockDto productFeatureStockDto)
        {
            var value = _mapper.Map<ProductFeatureStock>(productFeatureStockDto);
            await _stockCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductFeatureStockAsync(string id)
        {
            await _stockCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductFeatureStockDto>> GetAllProductFeatureStockAsync()
        {
            var values = await _stockCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductFeatureStockDto>>(values);
        }

        public async Task<GetByIdProductFeatureStockDto> GetByIdProductFeatureStockAsync(string id)
        {
            var value = await _stockCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductFeatureStockDto>(value);  
        }

        public async Task UpdateProductFeatureStockAsync(UpdateProductFeatureStockDto productFeatureStockDto)
        {
            var value = _mapper.Map<ProductFeatureStock>(productFeatureStockDto);
            await _stockCollection.FindOneAndReplaceAsync(x => x.ProductFeatureStockId == productFeatureStockDto.ProductFeatureStockId, value);
        }
    }
}
