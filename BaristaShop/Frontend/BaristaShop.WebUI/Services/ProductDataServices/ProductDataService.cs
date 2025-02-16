using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.ProductDetailServices;
using BaristaShop.WebUI.Services.ApiServices.ProductImageServices;
using BaristaShop.WebUI.Services.ApiServices.ProductItemServices;
using BaristaShop.WebUI.Services.ApiServices.ProductServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaristaShop.WebUI.Services.ProductDataServices
{
    public class ProductDataService : IProductDataService
    {
        private readonly IProductService _productService;
        private readonly IProductItemService _productItemService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;

        public ProductDataService(IProductService productService, IProductItemService productItemService, IProductDetailService productDetailService, IProductImageService productImageService)
        {
            _productService = productService;
            _productItemService = productItemService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
        }

        public async Task<List<ProductsWithAllAttributesViewModel>> GetAllProductDataAsync()
        {
            var productList = new List<ProductsWithAllAttributesViewModel>();

            var products = await _productService.GetAllProductAsync();

            if (products != null)
            {
                foreach (var item in products)
                {
                    var productId = item.ProductId;
                    var productName = item.ProductName;
                    var productIsActive = item.ProductIsActive;
                    var productcategoryId = item.CategoryId;

                    var productItems = await _productItemService.GetAllProductItemAsync();

                    if (productItems != null)
                    {
                        foreach (var pitem in productItems)
                        {
                            if (pitem.ProductId == productId)
                            {
                                var productPrice = pitem.ProductPrice;
                                var productStock = pitem.ProductStock;
                                var productSKU = pitem.SKU;
                                var productPriceWithSale = pitem.ProductPriceWithSale;

                                var productDetails = await _productDetailService.GetAllProductDetailAsync();

                                if (productDetails != null)
                                {
                                    foreach (var pdetail in productDetails)
                                    {
                                        if (pdetail.ProductId == productId)
                                        {
                                            var productDescription = pdetail.ProductDescription;
                                            var productInfo = pdetail.ProductInfo;

                                            var productImages = await _productImageService.GetAllProductImageAsync();

                                            if (productImages != null)
                                            {
                                                foreach (var pimage in productImages)
                                                {
                                                    if (pimage.ProductId == productId)
                                                    {
                                                        var image1 = pimage.Image1;
                                                        var image2 = pimage.Image2;
                                                        var image3 = pimage.Image3;
                                                        var image4 = pimage.Image4;
                                                        var image5 = pimage.Image5;
                                                        var image6 = pimage.Image6;

                                                        productList.Add(new ProductsWithAllAttributesViewModel
                                                        {
                                                            ProductId = productId,
                                                            ProductName = productName,
                                                            ProductIsActive = productIsActive,
                                                            CategoryId = productcategoryId,
                                                            ProductPrice = productPrice,
                                                            ProductStock = productStock,
                                                            SKU = productSKU,
                                                            ProductPriceWithSale = productPriceWithSale,
                                                            ProductDescription = productDescription,
                                                            ProductInfo = productInfo,
                                                            Image1 = image1,
                                                            Image2 = image2,
                                                            Image3 = image3,
                                                            Image4 = image4,
                                                            Image5 = image5,
                                                            Image6 = image6
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }       
                            }
                        }
                    }
                }
                    return productList;
            }
            
            // bunun yerine tabii şey yapılabilir her birinin servicinde productId ile getir gibi
            throw new KeyNotFoundException($"Products not found.");
        }

        public async Task<ProductDetailViewModel> GetProductDataAsync(string productId)
        {
            var productWithDetail = new ProductDetailViewModel();

            
            var product = await _productService.GetByIdProductAsync(productId);


            if((product != null) && (product.ProductIsActive == true))
            {
                var productName = product.ProductName;

                var productItem = await _productItemService.GetProductItemByProductIdAsync(productId);

                var productPrice = productItem.ProductPrice;
                var productStock = productItem.ProductStock;
                var productSKU = productItem.SKU;
                var productPriceWithSale = productItem.ProductPriceWithSale;


                var productDetail = await _productDetailService.GetProductDetailByProductIdAsync(productId);

                var productDescription = productDetail.ProductDescription;
                var productInfo = productDetail.ProductInfo;

                var productImages = await _productImageService.GetProductImageByProductIdAsync(productId);

                var image1 = productImages.Image1;
                var image2 = productImages.Image2;
                var image3 = productImages.Image3;
                var image4 = productImages.Image4;
                var image5 = productImages.Image5;
                var image6 = productImages.Image6;

                productWithDetail = new ProductDetailViewModel
                {
                    ProductId = productId,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductPriceWithSale = productPriceWithSale,
                    Image1 = image1,
                    Image2 = image2,
                    Image3 = image3,
                    Image4 = image4,
                    Image5 = image5,
                    Image6 = image6
                };

                return productWithDetail;
                                   
            } 
            
            // Ürün bulunamazsa uygun bir hata mesajı döndürülebilir
            throw new KeyNotFoundException($"Product with ID {productId} not found.");
            
        }

        public async Task<List<ProductPreviewViewModel>> GetAllProductPrevDataAsync()
        {

            var productPrevList = new List<ProductPreviewViewModel>();

            var products = await _productService.GetAllProductAsync();

            if (products != null)
                {
                    foreach (var item in products)
                    {
                        var productId = item.ProductId;
                        var productName = item.ProductName;
                        var productIsActive = item.ProductIsActive;
                        var productcategoryId = item.CategoryId;

                        
                        var productItems = await _productItemService.GetProductItemByProductIdAsync(productId);

                        if (productItems != null)
                            {
                                var productPrice = productItems.ProductPrice;
                                var productStock = productItems.ProductStock;
                                var productSKU = productItems.SKU;
                                var productPriceWithSale = productItems.ProductPriceWithSale;

                                var productImages = await _productImageService.GetProductImageByProductIdAsync(productId);

                            if (productImages != null)
                            {
                                var image1 = productImages.Image1;

                                productPrevList.Add(new ProductPreviewViewModel
                                {
                                    ProductId = productId,
                                    ProductName = productName,
                                    ProductIsActive = productIsActive,
                                    CategoryId = productcategoryId,
                                    ProductPrice = productPrice,
                                    ProductPriceWithSale = productPriceWithSale,
                                    Image1 = image1
                                });                                                                  
                            }
                        }
                    }
                    return productPrevList;
            }

            throw new KeyNotFoundException($"Products not found.");
        }

        public async Task<List<ProductPreviewViewModel>> GetAllProductPrevDataByCategoryIdAsync(string categoryId)
        {
            var allProducts = await GetAllProductPrevDataAsync();
            var products = allProducts.Where(p => p.CategoryId == categoryId).ToList();

            if (products != null && products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new KeyNotFoundException($"Products with Category ID {categoryId} not found.");
            }
        }
    }
}
