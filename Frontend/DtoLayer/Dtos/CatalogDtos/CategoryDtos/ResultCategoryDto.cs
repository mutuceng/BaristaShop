using BaristaShop.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryFeature> Features { get; set; } = new List<CategoryFeature>();
    }
}
