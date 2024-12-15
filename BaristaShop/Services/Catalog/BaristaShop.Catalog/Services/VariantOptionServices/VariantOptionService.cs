using AutoMapper;
using BaristaShop.Catalog.Dtos.VariantOptionDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.CategoryFeatureValueServices
{
    public class VariantOptionService : IVariantOptionService
    {
        IMongoCollection<VariantOption> _variantOptionCollection;
        IMapper _mapper;

        public VariantOptionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var database = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _variantOptionCollection = database.GetCollection<VariantOption>(_databaseSettings.VariantOptionCollectionName);

            _mapper = mapper;
        }

        public async Task CreateVariantOptionAsync(CreateVariantOptionDto categoryFeatureValueDto)
        {
            var value = _mapper.Map<VariantOption>(categoryFeatureValueDto);
            await _variantOptionCollection.InsertOneAsync(value);
        }

        public async Task DeleteVariantOptionAsync(string id)
        {
            await _variantOptionCollection.DeleteOneAsync(id);
        }

        public async Task<GetByIdVariantOptionDto> GetByIdVariantOptionAsync(string id)
        {
            var value = await _variantOptionCollection.FindAsync(x => x.VariantOptionId == id);
            return _mapper.Map<GetByIdVariantOptionDto>(value); 
        }

        public async Task<List<ResultVariantOptionDto>> GetAllVariantOptionsAsync()
        {
            var value = await _variantOptionCollection.Find( x => true).ToListAsync();
            return _mapper.Map<List<ResultVariantOptionDto>>(value);
        }

        public async Task UpdateVariantOptionAsync(UpdateVariantOptionDto categoryFeatureValueDto)
        {
            var value = _mapper.Map<VariantOption>(categoryFeatureValueDto);
            await _variantOptionCollection.FindOneAndReplaceAsync(x => x.VariantOptionId == value.VariantOptionId, value);
        }
    }
}
