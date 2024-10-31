using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DtoLayer.Dtos.ShippingBillDto
{
    public class CreateShippingBillDto
    {
 
        public int CargoDesi { get; set; }
        public string PacketType { get; set; }
        public double ShippingCharge { get; set; }

        public int ShipmentDetailId { get; set; }
    }
}
