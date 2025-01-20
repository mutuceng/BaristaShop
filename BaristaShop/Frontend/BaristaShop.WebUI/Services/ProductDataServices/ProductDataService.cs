using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using BaristaShop.WebUI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaristaShop.WebUI.Services.ProductDataServices
{
    public class ProductDataService : IProductDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<ProductsWithAllAttributesViewModel>> GetAllProductDataAsync()
        {
            var productList = new List<ProductsWithAllAttributesViewModel>();

            var client = _httpClientFactory.CreateClient();

            var productResponse = await client.GetAsync("https://localhost:7080/api/Products");
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJsonData);

                if(products != null)
                {
                    foreach (var item in products)
                    {
                        var productId = item.ProductId;
                        var productName = item.ProductName;
                        var productIsActive = item.ProductIsActive;
                        var productcategoryId = item.CategoryId;

                        var productItemResponse = await client.GetAsync($"https://localhost:7080/api/ProductItems");
                        if( productItemResponse.IsSuccessStatusCode )
                        {
                            var productItemJsonData = await productResponse.Content.ReadAsStringAsync();
                            var productItems = JsonConvert.DeserializeObject<List<ResultProductItemDto>>(productItemJsonData);

                            if(productItems != null)
                            {
                                foreach (var pitem in productItems)
                                {
                                    if (pitem.ProductId == productId)
                                    {
                                        var productPrice = pitem.ProductPrice;
                                        var productStock = pitem.ProductStock;
                                        var productSKU = pitem.SKU;
                                        var productPriceWithSale = pitem.ProductPriceWithSale;


                                        var productDetailResponse = await client.GetAsync($"https://localhost:7080/api/ProductDetails");
                                        if (productDetailResponse.IsSuccessStatusCode)
                                        {
                                            var productDetailJsonData = await productResponse.Content.ReadAsStringAsync();
                                            var productDetails = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(productDetailJsonData);

                                            if (productDetails != null)
                                            {
                                                foreach (var pdetail in productDetails)
                                                {
                                                    if (pdetail.ProductId == productId)
                                                    {
                                                        var productDescription = pdetail.ProductDescription;
                                                        var productInfo = pdetail.ProductInfo;

                                                        var productImageResponse = await client.GetAsync($"https://localhost:7080/api/ProductImages");
                                                        if (productImageResponse.IsSuccessStatusCode)
                                                        {
                                                            var productImageJsonData = await productResponse.Content.ReadAsStringAsync();
                                                            var productImages = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(productImageJsonData);


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
                            }
                        }
                    }
                    return productList;
                }
            }
            // bunun yerine tabii şey yapılabilir her birinin servicinde productId ile getir gibi
            throw new KeyNotFoundException($"Products not found.");
        }

        public async Task<ProductDetailViewModel> GetProductDataAsync(string productId)
        {
            var productWithDetail = new ProductDetailViewModel();

            var client = _httpClientFactory.CreateClient();
            var productResponse = await client.GetAsync("https://localhost:7080/api/Products/" + productId);
            if (productResponse.IsSuccessStatusCode)
            {
               var productJsonData = await productResponse.Content.ReadAsStringAsync();
               var product = JsonConvert.DeserializeObject<GetByIdProductDto>(productJsonData);

                if((product != null) && (product.ProductIsActive == true))
                {
                    var productName = product.ProductName;

                    var productItemResponse = await client.GetAsync($"https://localhost:7080/api/ProductItems/byproduct/" + productId);

                    if(productItemResponse.IsSuccessStatusCode)
                    {
                        var productItemJsonData = await productItemResponse.Content.ReadAsStringAsync();
                        var productItem = JsonConvert.DeserializeObject<ResultProductItemDto>(productItemJsonData);

                        var productPrice = productItem.ProductPrice;
                        var productStock = productItem.ProductStock;
                        var productSKU = productItem.SKU;
                        var productPriceWithSale = productItem.ProductPriceWithSale;


                        var productDetailResponse = await client.GetAsync($"https://localhost:7080/api/ProductDetails/byproduct/" + productId);
                        if (productDetailResponse.IsSuccessStatusCode)
                        {
                            var productDetailJsonData = await productDetailResponse.Content.ReadAsStringAsync();
                            var productDetail = JsonConvert.DeserializeObject<ResultProductDetailDto>(productDetailJsonData);

                            var productDescription = productDetail.ProductDescription;
                            var productInfo = productDetail.ProductInfo;

                            var productImageResponse = await client.GetAsync($"https://localhost:7080/api/ProductImages/byproduct/" + productId);
                            if (productImageResponse.IsSuccessStatusCode)
                            {
                                var productImageJsonData = await productImageResponse.Content.ReadAsStringAsync();
                                var productImages = JsonConvert.DeserializeObject<ResultProductImageDto>(productImageJsonData);

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
                        }

                    }

                } 
            } 
            
            // Ürün bulunamazsa uygun bir hata mesajı döndürülebilir
            throw new KeyNotFoundException($"Product with ID {productId} not found.");
            
        }

        public async Task<List<ProductPreviewViewModel>> GetAllProductPrevDataAsync()
        {

            var productPrevList = new List<ProductPreviewViewModel>();

            var client = _httpClientFactory.CreateClient();

            var productResponse = await client.GetAsync("https://localhost:7080/api/Products");
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJsonData);

                if (products != null)
                {
                    foreach (var item in products)
                    {
                        var productId = item.ProductId;
                        var productName = item.ProductName;
                        var productIsActive = item.ProductIsActive;
                        var productcategoryId = item.CategoryId;

                        
                        var productItemResponse = await client.GetAsync($"https://localhost:7080/api/ProductItems/byproduct/" + productId);
                        if (productItemResponse.IsSuccessStatusCode)
                        {
                            var productItemJsonData = await productItemResponse.Content.ReadAsStringAsync();
                            var productItems = JsonConvert.DeserializeObject<ResultProductItemDto>(productItemJsonData);

                            if (productItems != null)
                            {
                                var productPrice = productItems.ProductPrice;
                                var productStock = productItems.ProductStock;
                                var productSKU = productItems.SKU;
                                var productPriceWithSale = productItems.ProductPriceWithSale;

                                var productImageResponse = await client.GetAsync($"https://localhost:7080/api/ProductImages/byproduct/" + productId);
                                if (productImageResponse.IsSuccessStatusCode)
                                {
                                    var productImageJsonData = await productImageResponse.Content.ReadAsStringAsync();
                                    var productImages = JsonConvert.DeserializeObject<ResultProductImageDto>(productImageJsonData);

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
                        }
                    }
                    return productPrevList;
                }

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
