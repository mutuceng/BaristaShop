﻿namespace BaristaShop.Catalog.Dtos.ProductImageDtos
{
    public class GetProductImageByProductIdDto
    {
        public string ProductImageId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }


        public string ProductId { get; set; }
    }
}
