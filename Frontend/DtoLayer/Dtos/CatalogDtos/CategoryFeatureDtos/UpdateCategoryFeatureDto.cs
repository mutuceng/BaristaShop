using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryFeatureDtos
{
    public class UpdateCategoryFeatureDto
    {
        public string CategoryFeatureValueId { get; set; } 
        public string CategoryFeatureValueName { get; set; }
    }
}
