using BaristaShop.Catalog.Dtos.ProductFeatureStockDtos;
using BaristaShop.Catalog.Dtos.ProductImageDtos;
using BaristaShop.Catalog.Services.ProductFeatureStockServices;
using BaristaShop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureStocksController : ControllerBase
    {
        private readonly IProductFeatureStockService _productFeatureStockService;

        public ProductFeatureStocksController(IProductFeatureStockService productFeatureStockService)
        {
            _productFeatureStockService = productFeatureStockService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductFeatureStock()
        {
            var values = await _productFeatureStockService.GetAllProductFeatureStockAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductFeatureStockById(string id)
        {
            var values = await _productFeatureStockService.GetByIdProductFeatureStockAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductFeatureStock(CreateProductFeatureStockDto createProductFeatureStockDto)
        {
            await _productFeatureStockService.CreateProductFeatureStockAsync(createProductFeatureStockDto);
            return Ok("Successfully added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductFeatureStock(string id)
        {
            await _productFeatureStockService.DeleteProductFeatureStockAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductFeatureStock(UpdateProductFeatureStockDto updateProductFeatureStockDto)
        {
            await _productFeatureStockService.UpdateProductFeatureStockAsync(updateProductFeatureStockDto);
            return Ok("Successfully updated");
        }
    }     
}
