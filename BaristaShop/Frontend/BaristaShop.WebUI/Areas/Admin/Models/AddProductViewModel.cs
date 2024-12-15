using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;

namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        CreateProductDto CreateProductDto { get; set; }
        CreateProductItemDto CreateProductItemDto { get; set; }

        CreateProductDetailDto CreateProductDetailDto { get; set; }
        CreateProductImageDto CreateProductImageDto { get; set; }
    }
}
