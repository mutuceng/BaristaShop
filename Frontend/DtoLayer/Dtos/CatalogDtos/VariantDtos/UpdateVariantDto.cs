using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.VariantDtos
{
    public class UpdateVariantDto
    {
        public string VariantId { get; set; }
        public string VariantName { get; set; }

        public string CategoryId { get; set; }
    }
}
