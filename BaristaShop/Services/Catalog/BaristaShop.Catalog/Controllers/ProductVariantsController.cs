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
    public class ProductVariantsController : ControllerBase
    {
        private readonly IProductVariantService _productVariantService;

        public ProductVariantsController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductVariant()
        {
            var values = await _productVariantService.GetAllProductVariantAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductVariantById(string id)
        {
            var values = await _productVariantService.GetByIdProductVariantAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductVariant(CreateProductVariantDto createProductVariantDto)
        {
            await _productVariantService.CreateProductVariantAsync(createProductVariantDto);
            return Ok("Successfully added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductVariant(string id)
        {
            await _productVariantService.DeleteProductVariantAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductVariant(UpdateProductVariantDto updateProductVariantDto)
        {
            await _productVariantService.UpdateProductVariantAsync(updateProductVariantDto);
            return Ok("Successfully updated");
        }
    }     
}
