﻿using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryFeatureDtos
{
    public class GetByIdCategoryFeatureDto
    {
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
        public List<CategoryFeatureValue> FeatureValues { get; set; } = new List<CategoryFeatureValue>();
    }
}
