using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UINavbarViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public UINavbarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();

            var model = new List<NavbarCategoriesViewModel>();

            model = values
            .OrderBy(item => item.CategoryName) // CategoryName'e göre alfabetik sıralama yap
            .Select(item => new NavbarCategoriesViewModel
            {
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName
            })
            .ToList();

            return View(model);
        }
    }
}
