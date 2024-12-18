using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos
{
    public class GetByIdFeatureSliderDto
    {
        public string FeatureSliderId { get; set; }
        public string FeatureSliderTitle { get; set; }
        public string FeatureSliderDescription { get; set; }
        public string FeatureSliderImage { get; set; }
    }
}
