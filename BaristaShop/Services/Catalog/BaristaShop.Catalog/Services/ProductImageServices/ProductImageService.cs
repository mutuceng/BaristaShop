﻿using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductImageDtos;
using BaristaShop.Catalog.Dtos.ProductItemDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.Catalog.Settings;
using MongoDB.Driver;

namespace BaristaShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.FindAsync(x => x.ProductImageId == id);
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, value);
        }

        public async Task<ResultProductImageDto> GetProductImageByProductIdAsync(string id)
        {
            var cursor = await _productImageCollection.FindAsync(x => x.ProductId == id);
            var value = await cursor.FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(value);
        }

    }
}
