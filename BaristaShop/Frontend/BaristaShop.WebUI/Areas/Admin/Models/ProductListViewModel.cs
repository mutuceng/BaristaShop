using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace BaristaShop.WebUI.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public List<ResultProductDto> Products { get; set; } // Ürün listesi
        public List<ResultProductDetailDto> ProductDetails { get; set; } // Ürün detayları listesi
        public List<ResultProductImageDto> ProductImages { get; set; } // Ürün görselleri
    }
}
