using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Entities;
using AutoMapper;
using BaristaShop.Catalog.Dtos.ProductDtos;
using BaristaShop.Catalog.Dtos.ProductDetailDtos;
using BaristaShop.Catalog.Dtos.ProductImageDtos;
using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Dtos.VariantOptionDtos;
using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;
using BaristaShop.Catalog.Dtos.ProductItemDtos;
using BaristaShop.Catalog.Dtos.FeatureSliderDtos;
using BaristaShop.Catalog.Dtos.SpecialOfferDtos;
using BaristaShop.Catalog.Dtos.AboutUsDtos;

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

            CreateMap<Variant, ResultVariantDto>().ReverseMap();
            CreateMap<Variant, CreateVariantDto>().ReverseMap();
            CreateMap<Variant, GetByIdVariantDto>().ReverseMap();
            CreateMap<Variant, UpdateVariantDto>().ReverseMap();

            CreateMap<VariantOption, ResultVariantOptionDto>().ReverseMap();
            CreateMap<VariantOption, CreateVariantOptionDto>().ReverseMap();
            CreateMap<VariantOption, GetByIdVariantOptionDto>().ReverseMap();
            CreateMap<VariantOption, UpdateVariantOptionDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductItem, ResultProductItemDto>().ReverseMap();
            CreateMap<ProductItem, CreateProductItemDto>().ReverseMap();
            CreateMap<ProductItem, GetByIdProductItemDto>().ReverseMap();
            CreateMap<ProductItem, UpdateProductItemDto>().ReverseMap();
            CreateMap<ProductItem, GetProductItemByProductIdDto>().ReverseMap();

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

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

            CreateMap<AboutUs, ResultAboutUsDto>().ReverseMap();
            CreateMap<AboutUs, CreateAboutUsDto>().ReverseMap();

        }

    }
}
