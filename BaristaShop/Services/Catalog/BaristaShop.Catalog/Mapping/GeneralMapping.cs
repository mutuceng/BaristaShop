using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Entities;
using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductDtos;
using BaristaShop.Catalog.Dtos.ProductDetailDtos;
using BaristaShop.Catalog.Dtos.ProductImageDtos;
using BaristaShop.Catalog.Dtos.CategoryFeatureDtos;
using BaristaShop.Catalog.Dtos.CategoryFeatureValueDtos;
using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;

namespace BaristaShop.Catalog.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<CategoryFeature, ResultCategoryFeatureDto>().ReverseMap();
            CreateMap<CategoryFeature, CreateCategoryFeatureDto>().ReverseMap();
            CreateMap<CategoryFeature, GetByIdCategoryFeatureDto>().ReverseMap();
            CreateMap<CategoryFeature, UpdateCategoryFeatureDto>().ReverseMap();

            CreateMap<CategoryFeatureValue, ResultCategoryFeatureValueDto>().ReverseMap();
            CreateMap<CategoryFeatureValue, CreateCategoryFeatureValueDto>().ReverseMap();
            CreateMap<CategoryFeatureValue, GetByIdCategoryFeatureValueDto>().ReverseMap();
            CreateMap<CategoryFeatureValue, UpdateCategoryFeatureValueDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<ProductVariant, ResultProductVariantDto>().ReverseMap();
            CreateMap<ProductVariant, CreateProductVariantDto>().ReverseMap();
            CreateMap<ProductVariant, GetByIdProductVariantDto>().ReverseMap();
            CreateMap<ProductVariant, UpdateProductVariantDto>().ReverseMap();

            CreateMap<ProductVariantImage, ResultProductVariantImageDto>().ReverseMap();
            CreateMap<ProductVariantImage, CreateProductVariantImageDto>().ReverseMap();
            CreateMap<ProductVariantImage, GetByIdProductVariantImageDto>().ReverseMap();
            CreateMap<ProductVariantImage, UpdateProductVariantImageDto>().ReverseMap();
        }

    }
}
