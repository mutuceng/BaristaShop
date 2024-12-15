using BaristaShop.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.VariantDtos
{
    public class CreateVariantDto
    {
        public string VariantName { get; set; }

        public string CategoryId { get; set; }

    }
}
