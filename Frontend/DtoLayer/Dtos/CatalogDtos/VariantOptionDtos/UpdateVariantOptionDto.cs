using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.VariantOptionDtos
{
    public class UpdateVariantOptionDto
    {
        public string VariantOptionId { get; set; }
        public string VariantOptionValue { get; set; }


        public string VariantId { get; set; }
    }
}
