using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Services.CategoryFeatureServices;
using BaristaShop.Catalog.Services.CategoryFeatureValueServices;
using BaristaShop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantsController : ControllerBase
    {
        private readonly IVariantService _variantService;

        public VariantsController(IVariantService categoryFeatureService)
        {
            _variantService = categoryFeatureService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryFeatureList()
        {
            var values = await _variantService.GetAllVariantsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryFeatureById(string id)
        {
            var value = await _variantService.GetByIdVariantAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryFeature(CreateVariantDto createCategoryFeatureDto)
        {
            await _variantService.CreateVariantAsync(createCategoryFeatureDto);
            return Ok("Successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryFeature(string id)
        {
            await _variantService.DeleteVariantAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateVariantDto updateCategoryFeatureDto)
        {
            await _variantService.UpdateVariantAsync(updateCategoryFeatureDto);
            return Ok("Successfully updated");
        }
    }
}
