using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.EntityLayer.Concrete
{
    public enum CargoStatus
    {
        Preparing, // Hazırlanıyor
        Dispatched, // Kargo'ya verildi
        InTransit // Yola çıktı
    }
        public class ShipmentDetail
        {
            public int ShipmentDetailId { get; set; }
            public string Consignor { get; set; } // Gönderen
            public string Consignee { get; set; } // Alıcı
            public string Origin { get; set; }
            public string Destination { get; set; }
            public int TrackId { get; set; }


            public int ShippingBillId { get; set; }
            [ForeignKey("ShippingBillId")]
            public ShippingBill ShippingBill { get; set; }

            public int CargoCompanyId { get; set; }
            [ForeignKey("CargoCompanyId")]
            public CargoCompany CargoCompany { get; set; }

            public List<ShipmentOperation> ShipmentOperations { get; set; }

    }
}
