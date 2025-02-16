using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using BaristaShop.WebUI.Services.ApiServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BaristaShop.WebUI.ViewComponents.UIHomeViewComponents
{
    public class UIHomeFeaturedCampaignViewComponent:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public UIHomeFeaturedCampaignViewComponent(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var specialOffers = await _specialOfferService.GetAllSpecialOfferAsync();
                return View(specialOffers);
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown here)
                return View(new List<ResultSpecialOfferDto>()); // Return an empty list if an error occurs
            }
        }
    }
}
