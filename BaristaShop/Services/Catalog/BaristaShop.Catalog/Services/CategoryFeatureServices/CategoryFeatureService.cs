using AutoMapper;
using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Dtos.CategoryFeatureDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.CategoryFeatureServices
{
    public class CategoryFeatureService : ICategoryFeatureService
    {
        private readonly IMongoCollection<CategoryFeature> _categoryFeatureCollection;
        private readonly IMapper _mapper;

        public CategoryFeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryFeatureCollection = database.GetCollection<CategoryFeature>(_databaseSettings.CategoryFeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryFeatureAsync(CreateCategoryFeatureDto createCategoryFeatureDto)
        {
            var value = _mapper.Map<CategoryFeature>(createCategoryFeatureDto);
            await _categoryFeatureCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryFeatureAsync(string id)
        {
            await _categoryFeatureCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultCategoryFeatureDto>> GetAllFeaturesAsync()
        {
            var values = await _categoryFeatureCollection.Find(x => true).ToListAsync(); 
            return _mapper.Map<List<ResultCategoryFeatureDto>>(values);
        }

        public async Task<GetByIdCategoryFeatureDto> GetByIdCategoryFeatureAsync(string id)
        {
            var value = await _categoryFeatureCollection.Find(x => x.CategoryFeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryFeatureDto>(value);
        }

        public async Task UpdateCategoryFeatureAsync(UpdateCategoryFeatureDto updateCategoryFeatureDto)
        {
            var value = _mapper.Map<CategoryFeature>(updateCategoryFeatureDto);
            await _categoryFeatureCollection.FindOneAndReplaceAsync(x => x.CategoryFeatureId == updateCategoryFeatureDto.CategoryFeatureId, value);
            
        }
    }
}
