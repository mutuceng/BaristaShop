﻿using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryFeature> Feature { get; set; } = new List<CategoryFeature>();
    }
}
