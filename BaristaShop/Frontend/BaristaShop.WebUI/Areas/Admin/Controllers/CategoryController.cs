using BaristaShop.Catalog.Dtos.VariantDtos;
using BaristaShop.Catalog.Entities;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using BaristaShop.WebUI.Services.ApiServices.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Listesi";

            /*
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7080/api/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                    return View(values);
                }               
            */
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }


        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Ekleme";


           
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(AddCategoryImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                string folder = Path.Combine("wwwroot","images", "categoryImages");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (model.CategoryImage != null && model.CategoryImage.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.CategoryImage.FileName);

                    string filePath = Path.Combine(folder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.CategoryImage.CopyToAsync(fileStream);
                    }

                    string relativePath = Path.Combine("images", "categoryImages", uniqueFileName).Replace("\\", "/");

                    var createCategoryDto = new CreateCategoryDto
                    {
                        CategoryName = model.CategoryName,
                        CategoryImage = relativePath
                    };

                    /*
                        var client = _httpClientFactory.CreateClient();
                        var jsonData = JsonConvert.SerializeObject(createCategoryDto);
                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync("https://localhost:7080/api/Categories", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Category", new { area = "Admin" });
                        }
                    */

                    await _categoryService.CreateCategoryAsync(createCategoryDto);
                    return RedirectToAction("Index", "Category", new { area = "Admin" });

                }
            } else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(model);
        }

        
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            //var response = await client.DeleteAsync("https://localhost:7080/api/Categories?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Category", new { area = "Admin" });
            //}

            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }

        // silme işlemi için https://localhost:7080/api/Categories?id=id
        // güncelleme için   https://localhost:7080/api/Categories/id

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Kategori Güncelleme";

            var value = await _categoryService.GetByIdCategoryAsync(id);

            var updateCategoryDto = new UpdateCategoryDto
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName,
                CategoryImage = value.CategoryImage
            };

            return View(updateCategoryDto);
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);

                //var client = _httpClientFactory.CreateClient();
                //var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
                //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                //var response = await client.PutAsync("https://localhost:7080/api/Categories", content);
                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index", "Category", new { area = "admin" });
                //}

                return RedirectToAction("Index", "Category", new { area = "admin" });

            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }


            return View(updateCategoryDto);
        }
    }
}
