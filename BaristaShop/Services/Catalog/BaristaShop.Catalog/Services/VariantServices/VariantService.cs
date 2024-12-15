using AutoMapper;
using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Dtos.VariantOptionDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.CategoryFeatureServices
{
    public class VariantService : IVariantService
    {
        private readonly IMongoCollection<Variant> _variantCollection;
        private readonly IMapper _mapper;

        public VariantService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _variantCollection = database.GetCollection<Variant>(_databaseSettings.VariantCollectionName);
            _mapper = mapper;
        }

        public async Task CreateVariantAsync(CreateVariantDto createCategoryFeatureDto)
        {
            var value = _mapper.Map<Variant>(createCategoryFeatureDto);
            await _variantCollection.InsertOneAsync(value);
        }

        public async Task DeleteVariantAsync(string id)
        {
            await _variantCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultVariantDto>> GetAllVariantsAsync()
        {
            var values = await _variantCollection.Find(x => true).ToListAsync(); 
            return _mapper.Map<List<ResultVariantDto>>(values);
        }

        public async Task<GetByIdVariantDto> GetByIdVariantAsync(string id)
        {
            var value = await _variantCollection.Find(x => x.VariantId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdVariantDto>(value);
        }

        public async Task UpdateVariantAsync(UpdateVariantDto updateCategoryFeatureDto)
        {
            var value = _mapper.Map<Variant>(updateCategoryFeatureDto);
            await _variantCollection.FindOneAndReplaceAsync(x => x.VariantId == updateCategoryFeatureDto.VariantId, value);
                
        }

        public async Task<List<GetByIdVariantOptionDto>> GetByIdsAsync(List<string> ids)
        {

            // Veritabanından ID'lere göre sorgula
            var categoryFeatures = await _variantCollection
                .Find(x => ids.Contains(x.VariantId))
                .ToListAsync();

            return _mapper.Map<List<GetByIdVariantOptionDto>>(categoryFeatures);
        }
    }
}
