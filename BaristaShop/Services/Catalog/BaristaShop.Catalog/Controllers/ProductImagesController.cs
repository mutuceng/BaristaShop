using BaristaShop.Catalog.Dtos.ProductImageDtos;
using BaristaShop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductImage()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Successfully added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Successfully updated");
        }

        [HttpGet("byproduct/{productId}")]
        public async Task<IActionResult> GetProductImageByProductId(string productId)
        {
            var value = await _productImageService.GetProductImageByProductIdAsync(productId);
            return Ok(value);
        }


    }
}
