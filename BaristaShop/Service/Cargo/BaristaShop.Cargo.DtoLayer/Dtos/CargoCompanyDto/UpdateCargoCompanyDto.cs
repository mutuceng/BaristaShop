﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DtoLayer.Dtos.CargoCompanyDto
{
    public class UpdateCargoCompanyDto
    {
        public int CargoCompanyId { get; set; }
        public string CargoCompanyName { get; set; }
        public string CargoCompanyPhone { get; set; }
        public string Email { get; set; }
    }
}
