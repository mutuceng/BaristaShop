using BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos;
using BaristaShop.WebUI.Services.ApiServices.ProductItemServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductItem")]
    [AllowAnonymous]
    public class ProductItemController : Controller
    {
        private readonly IProductItemService _productItemService;

        public ProductItemController(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        [HttpGet]
        [Route("CreateProductItem/{id}")]
        public IActionResult CreateProductItem(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme II ";


            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        [Route("CreateProductItem/{id}")]
        public async Task<IActionResult> CreateProductItem(CreateProductItemDto model)
        {
            if (ModelState.IsValid)
            {
                var createProductItemDto = new CreateProductItemDto
                {
                    ProductId = model.ProductId,
                    ProductPrice = model.ProductPrice,
                    ProductPriceWithSale = model.ProductPriceWithSale,
                    ProductStock = model.ProductStock,
                    SKU = model.SKU,
                };

                await _productItemService.CreateProductItemAsync(createProductItemDto);

                
                return RedirectToAction("CreateProductDetail", "ProductDetail", new { area = "Admin", id = model.ProductId });
                
            }
            else
            {
                // ModelState hatalarını inceleyin.
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(model);
        }
    }
}
