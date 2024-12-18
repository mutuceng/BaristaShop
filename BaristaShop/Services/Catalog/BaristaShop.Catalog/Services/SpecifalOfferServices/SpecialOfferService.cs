using AutoMapper;
using BaristaShop.Catalog.Dtos.SpecialOfferDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.SpecifalOfferServices
{
    public class SpecialOfferService:ISpecialOfferService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOfferCollection.FindAsync(x => x.SpecialOfferId == id);
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, value);
        }
    }
}
