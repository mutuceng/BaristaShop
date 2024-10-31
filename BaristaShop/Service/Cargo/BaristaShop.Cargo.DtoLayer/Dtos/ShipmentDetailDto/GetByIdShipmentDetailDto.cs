using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DtoLayer.Dtos.ShippingDetailDto
{
    public class GetByIdShipmentDetailDto
    {
        public int ShipmentDetailId { get; set; }
        public string Consignor { get; set; } // Gönderen
        public string Consignee { get; set; } // Alıcı
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int TrackId { get; set; }

        public int ShippingBillId { get; set; }

        public int CargoCompanyId { get; set; }
    }
}
