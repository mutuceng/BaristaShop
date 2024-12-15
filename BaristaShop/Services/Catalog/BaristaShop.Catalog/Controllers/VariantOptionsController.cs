using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Dtos.VariantOptionDtos;
using BaristaShop.Catalog.Services.CategoryFeatureValueServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantOptionsController : ControllerBase
    {
        private readonly IVariantOptionService _variantOptionService;

        public VariantOptionsController(IVariantOptionService categoryFeatureValueService)
        {
            _variantOptionService = categoryFeatureValueService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryFeatureValueList()
        {
            var values = await _variantOptionService.GetAllVariantOptionsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryFeatureValueById(string id)
        {
            var value = await _variantOptionService.GetByIdVariantOptionAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryFeatureValue(CreateVariantOptionDto createCategoryFeatureValueDto)
        {
            await _variantOptionService.CreateVariantOptionAsync(createCategoryFeatureValueDto);
            return Ok("Successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> CreateCategoryFeatureValue(string id)
        {
            await _variantOptionService.DeleteVariantOptionAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> CreateCategoryFeatureValue(UpdateVariantOptionDto updateCategoryFeatureValueDto)
        {
            await _variantOptionService.UpdateVariantOptionAsync(updateCategoryFeatureValueDto);
            return Ok("Successfully updated");
        }
    }
}
