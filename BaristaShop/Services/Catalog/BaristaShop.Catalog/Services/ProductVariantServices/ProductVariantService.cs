﻿using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.ProductFeatureStockServices
{
    public class ProductVariantService : IProductVariantService
    {
        IMongoCollection<ProductVariant> _productVariantCollection;
        IMapper _mapper;

        public ProductVariantService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            var stockCollection = database.GetCollection<ProductVariant>(_databaseSettings.ProductVariantCollectionName);

            _mapper = mapper;
        }

        public async Task CreateProductVariantAsync(CreateProductVariantDto createProductVariantDto)
        {
            var value = _mapper.Map<ProductVariant>(createProductVariantDto);
            await _productVariantCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductVariantAsync(string id)
        {
            await _productVariantCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductVariantDto>> GetAllProductVariantAsync()
        {
            var values = await _productVariantCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductVariantDto>>(values);
        }

        public async Task<GetByIdProductVariantDto> GetByIdProductVariantAsync(string id)
        {
            var value = await _productVariantCollection.Find(x => x.ProductItemId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductVariantDto>(value);  
        }

        public async Task UpdateProductVariantAsync(UpdateProductVariantDto updateProductVariantDto)
        {
            var value = _mapper.Map<ProductVariant>(updateProductVariantDto);
            await _productVariantCollection.FindOneAndReplaceAsync(x => x.ProductVariantId == updateProductVariantDto.ProductVariantId, value);
        }
    }
}
