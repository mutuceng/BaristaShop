using AutoMapper;
using BaristaShop.Catalog.Dtos.CategoryFeatureValueDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.CategoryFeatureValueServices
{
    public class CategoryFeatureValueService : ICategoryFeatureValueService
    {
        IMongoCollection<CategoryFeatureValue> _featureValueCollection;
        IMapper _mapper;

        public CategoryFeatureValueService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var database = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _featureValueCollection = database.GetCollection<CategoryFeatureValue>(_databaseSettings.CategoryFeatureValueCollectionName);

            _mapper = mapper;
        }

        public async Task CreateCategoryFeatureValueAsync(CreateCategoryFeatureValueDto categoryFeatureValueDto)
        {
            var value = _mapper.Map<CategoryFeatureValue>(categoryFeatureValueDto);
            await _featureValueCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryFeatureValueAsync(string id)
        {
            await _featureValueCollection.DeleteOneAsync(id);
        }

        public async Task<GetByIdCategoryFeatureValueDto> GetByIdCategoryFeatureValueAsync(string id)
        {
            var value = await _featureValueCollection.FindAsync(x => x.CategoryFeatureValueId == id);
            return _mapper.Map<GetByIdCategoryFeatureValueDto>(value); 
        }

        public async Task<List<ResultCategoryFeatureValueDto>> GetAllCategoryFeatureValueAsync()
        {
            var value = await _featureValueCollection.Find( x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryFeatureValueDto>>(value);
        }

        public async Task UpdateCategoryFeatureValueAsync(UpdateCategoryFeatureValueDto categoryFeatureValueDto)
        {
            var value = _mapper.Map<CategoryFeatureValue>(categoryFeatureValueDto);
            await _featureValueCollection.FindOneAndReplaceAsync(x => x.CategoryFeatureValueId == value.CategoryFeatureValueId, value);
        }
    }
}
