using BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using BaristaShop.WebUI.Areas.Admin.Models;
using BaristaShop.WebUI.Services.ApiServices.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BaristaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductItem")]
    [AllowAnonymous]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        [Route("CreateProductImage/{id}")]
        public IActionResult CreateProductImage(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ürün Ekleme II ";


            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        [Route("CreateProductImage/{id}")]
        public async Task<IActionResult> CreateProductImage(AddProductImagesViewModel model)
        {
            if (ModelState.IsValid)
            {
                string folder = Path.Combine("wwwroot", "images", "productImages");
                int a = 0;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                List<string> filePaths = new List<string>();

                foreach(var imageFile in model.ProductImages)
                {

                    if (imageFile != null && imageFile.Length > 0) // Dosya geçerli mi?
                    {
                        // Benzersiz dosya adı oluştur (Guid ile)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);

                        // Tam dosya yolu
                        string filePath = Path.Combine(folder, uniqueFileName);

                        // Dosyayı sunucuya kaydet
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }

                        // Dosya yolunu kaydet (wwwroot'u çıkartarak göreceli yol)
                        string relativePath = Path.Combine("images", "productImages", uniqueFileName).Replace("\\", "/");
                        filePaths.Add(relativePath);
                        a++;
                    }
                }

                var createProductImageDto = new CreateProductImageDto
                {
                    Image1 = filePaths[0],
                    Image2 = filePaths[1],
                    Image3 = filePaths[2],
                    Image4 = filePaths.Count > 3 ? filePaths[3] : null,
                    Image5 = filePaths.Count > 4 ? filePaths[4] : null,
                    Image6 = filePaths.Count > 5 ? filePaths[5] : null,
                    ProductId = model.ProductId
                };


                await _productImageService.CreateProductImageAsync(createProductImageDto);

                return RedirectToAction("Index", "Product", new { area = "Admin" });

                /* var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductImageDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7080/api/ProductImages", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product", new { area = "Admin" });
                }
                */
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
