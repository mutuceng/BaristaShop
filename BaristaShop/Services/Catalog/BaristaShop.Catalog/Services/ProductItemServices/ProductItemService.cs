using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductItemDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.ProductItemServices
{
    public class ProductItemService:IProductItemService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductItem> _productItemCollection;

        public ProductItemService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productItemCollection = database.GetCollection<ProductItem>(_databaseSettings.ProductItemCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductItemAsync(CreateProductItemDto createProductItemDto)
        {
            var value = _mapper.Map<ProductItem>(createProductItemDto);
            await _productItemCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductItemAsync(string id)
        {
            await _productItemCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductItemDto>> GetAllProductItemAsync()
        {
            var values = await _productItemCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductItemDto>>(values);
        }

        public async Task<GetByIdProductItemDto> GetByIdProductItemAsync(string id)
        {
            var value = await _productItemCollection.FindAsync(x => x.ProductItemId == id);
            return _mapper.Map<GetByIdProductItemDto>(value);
        }

        public async Task UpdateProductItemAsync(UpdateProductItemDto updateProductItemDto)
        {
            var value = _mapper.Map<ProductItem>(updateProductItemDto);
            await _productItemCollection.FindOneAndReplaceAsync(x => x.ProductItemId == updateProductItemDto.ProductItemId, value);
        }
    }
}
