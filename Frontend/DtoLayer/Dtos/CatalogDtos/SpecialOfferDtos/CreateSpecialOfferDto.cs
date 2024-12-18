using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos
{
    public class CreateSpecialOfferDto
    {
        public string SpecialOfferTitle { get; set; }
        public string SpecialOfferSubTitle { get; set; }
        public string SpecialOfferImage { get; set; }
    }
}
