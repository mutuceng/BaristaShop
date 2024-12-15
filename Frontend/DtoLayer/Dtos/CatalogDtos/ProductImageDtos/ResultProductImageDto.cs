using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos
{
    public class ResultProductImageDto
    {
        public string ProductImageId { get; set; }
        public List<string> Images { get; set; } = new List<string>();


        public string ProductId { get; set; }

    }

}
