﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.CatalogDtos.ProductItemDtos
{
    public class GetProductItemByProductIdDto
    {
        public string ProductItemId { get; set; }
        public string ProductId { get; set; }
        public string SKU { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductPriceWithSale { get; set; }
    }
}
