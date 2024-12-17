using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos
{
    public class CreateProductImageDto
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }


        public string ProductId { get; set; }
    }; 
}
