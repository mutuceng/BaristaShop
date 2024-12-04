using BaristaShop.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryFeatureDtos
{
    public class CreateCategoryFeatureDto
    {
        public string CategoryFeatureName { get; set; }
        public List<CategoryFeatureValue> CategoryFeatureValues { get; set; }

    }
}
