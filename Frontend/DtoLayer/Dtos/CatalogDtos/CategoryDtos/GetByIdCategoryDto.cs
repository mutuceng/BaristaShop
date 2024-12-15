using BaristaShop.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
