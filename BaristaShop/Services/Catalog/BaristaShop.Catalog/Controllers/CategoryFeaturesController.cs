using BaristaShop.Catalog.Dtos.CategoryDtos;
using BaristaShop.Catalog.Dtos.CategoryFeatureDtos;
using BaristaShop.Catalog.Services.CategoryFeatureServices;
using BaristaShop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryFeaturesController : ControllerBase
    {
        private readonly ICategoryFeatureService _categoryFeatureService;

        public CategoryFeaturesController(ICategoryFeatureService categoryFeatureService)
        {
            _categoryFeatureService = categoryFeatureService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryFeatureList()
        {
            var values = await _categoryFeatureService.GetAllFeaturesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryFeatureById(string id)
        {
            var value = await _categoryFeatureService.GetByIdCategoryFeatureAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryFeature(CreateCategoryFeatureDto createCategoryFeatureDto)
        {
            await _categoryFeatureService.CreateCategoryFeatureAsync(createCategoryFeatureDto);
            return Ok("Successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryFeature(string id)
        {
            await _categoryFeatureService.DeleteCategoryFeatureAsync(id);
            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryFeatureDto updateCategoryFeatureDto)
        {
            await _categoryFeatureService.UpdateCategoryFeatureAsync(updateCategoryFeatureDto);
            return Ok("Successfully updated");
        }
    }
}
