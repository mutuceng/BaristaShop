using BaristaShop.Catalog.Dtos.ProductDtos;
using BaristaShop.Catalog.Dtos.ProductItemDtos;
using BaristaShop.Catalog.Services.ProductItemServices;
using BaristaShop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly IProductItemService _productItemService;

        public ProductItemsController(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductItemList()
        {
            var values = await _productItemService.GetAllProductItemAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductItemById(string id)
        {
            var value = await _productItemService.GetByIdProductItemAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductItem(CreateProductItemDto createProductItemDto)
        {
            await _productItemService.CreateProductItemAsync(createProductItemDto);
            return Ok("Successfully added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductItem(string id)
        {
            await _productItemService.DeleteProductItemAsync(id);
            return Ok("Succesfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductItem(UpdateProductItemDto updateProductItemDto)
        {
            await _productItemService.UpdateProductItemAsync(updateProductItemDto);
            return Ok("Successfully updated");
        }

        [HttpGet("byproduct/{productId}")]
        public async Task<IActionResult> GetProductItemByProductId(string productId)
        {
            var value = await _productItemService.GetProductItemByProductIdAsync(productId);
            return Ok(value);
        }
    }
}
