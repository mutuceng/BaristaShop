using AutoMapper;
using BaristaShop.Catalog.Dtos.AboutUsDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.AboutUsServices
{
    public class AboutUsService:IAboutUsService
    {
        private readonly IMongoCollection<AboutUs> _aboutUsCollection;
        private readonly IMapper _mapper;

        public AboutUsService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutUsCollection = database.GetCollection<AboutUs>(_databaseSettings.AboutUsCollectionName);
            _mapper = mapper;
        }
        public async Task CreateAboutUsAsync(CreateAboutUsDto createAboutUsDto)
        {
            var value = _mapper.Map<AboutUs>(createAboutUsDto);
            await _aboutUsCollection.InsertOneAsync(value);
        }

        public async Task<ResultAboutUsDto> GetAboutUsAsync()
        {
            var values = await _aboutUsCollection.Find(x => true).ToListAsync(); // gets all values
            return _mapper.Map<ResultAboutUsDto>(values);
        }

        public async Task UpdateAboutUsAsync(UpdateAboutUsDto updateAboutUsDto)
        {
            var values = _mapper.Map<AboutUs>(updateAboutUsDto);
            await _aboutUsCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutUsDto.AboutId, values);
        }
    }
}
