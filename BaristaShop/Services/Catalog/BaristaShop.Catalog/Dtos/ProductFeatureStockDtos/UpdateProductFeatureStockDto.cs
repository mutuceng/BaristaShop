﻿namespace BaristaShop.Catalog.Dtos.ProductFeatureStockDtos
{
    public class UpdateProductFeatureStockDto
    {
        public string ProductFeatureStockId { get; set; }
        public int ProductVariableStock { get; set; }
        public string ProductId { get; set; }
        public string CategoryFeatureValueId { get; set; }
    }
}