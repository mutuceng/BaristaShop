using BaristaShop.DtoLayer.Dtos.BasketDtos;
using BaristaShop.WebUI.Models;
using BaristaShop.WebUI.Services.ApiServices.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.WebUI.ViewComponents.UIOrderViewComponents
{
    public class UIOrderOrderSummaryViewComponent:ViewComponent
    {
        private readonly IBasketService _basketService;

        public UIOrderOrderSummaryViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(OrderDetailViewModel orderDetailViewModel)
        {
            var basket = await _basketService.GetBasketAsync();
            var basketItems = new List<BasketItemDto>();

            var totalPrice = orderDetailViewModel.TotalPrice;

            var OrderSummaryViewModel = new OrderSummaryViewModel();

            if(orderDetailViewModel.DiscountRate != 0 &&  orderDetailViewModel.DiscountRate != null)
            {
                totalPrice -= totalPrice * orderDetailViewModel.DiscountRate.GetValueOrDefault();
                var totalPriceWithTax = totalPrice + totalPrice * (orderDetailViewModel.Tax / 100);

                OrderSummaryViewModel.TotalPriceWithDiscount = totalPrice;
                OrderSummaryViewModel.Tax = orderDetailViewModel.Tax;
                OrderSummaryViewModel.TotalPriceWithTax = totalPriceWithTax;

            }
            else
            {
                var totalPriceWithTax = totalPrice + totalPrice * (orderDetailViewModel.Tax / 100);

                OrderSummaryViewModel.TotalPrice = totalPrice;
                OrderSummaryViewModel.Tax = orderDetailViewModel.Tax;
                OrderSummaryViewModel.TotalPriceWithTax = totalPriceWithTax;
            }

            foreach (var item in basket.BasketItems)
            {
                var items = new BasketItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                basketItems.Add(items);
            }

            OrderSummaryViewModel.BasketItems = basketItems;

            return View(OrderSummaryViewModel);
        }
    }
}
