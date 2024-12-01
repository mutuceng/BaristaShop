﻿using BaristaShop.Catalog.Entities;

namespace BaristaShop.Catalog.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public List<CategoryFeature> Feature { get; set; } = new List<CategoryFeature>();
    }
}
