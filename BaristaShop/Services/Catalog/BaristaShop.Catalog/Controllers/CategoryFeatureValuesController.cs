using BaristaShop.Catalog.Dtos.CategoryFeatureDtos;
using BaristaShop.Catalog.Dtos.CategoryFeatureValueDtos;
using BaristaShop.Catalog.Services.CategoryFeatureValueServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryFeatureValuesController : ControllerBase
    {
        private readonly ICategoryFeatureValueService _categoryFeatureValueService;

        public CategoryFeatureValuesController(ICategoryFeatureValueService categoryFeatureValueService)
        {
            _categoryFeatureValueService = categoryFeatureValueService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryFeatureValueList()
        {
            var values = await _categoryFeatureValueService.GetAllCategoryFeatureValueAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryFeatureValueById(string id)
        {
            var value = await _categoryFeatureValueService.GetByIdCategoryFeatureValueAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryFeature(CreateCategoryFeatureValueDto createCategoryFeatureValueDto)
        {
            await _categoryFeatureValueService.CreateCategoryFeatureValueAsync(createCategoryFeatureValueDto);
            return Ok("Successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryFeature(string id)
        {
            await _categoryFeatureValueService.DeleteCategoryFeatureValueAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryFeatureValueDto updateCategoryFeatureValueDto)
        {
            await _categoryFeatureValueService.UpdateCategoryFeatureValueAsync(updateCategoryFeatureValueDto);
            return Ok("Successfully updated");
        }
    }
}
