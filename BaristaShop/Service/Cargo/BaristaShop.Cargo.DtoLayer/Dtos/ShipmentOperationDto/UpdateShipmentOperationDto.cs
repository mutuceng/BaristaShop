using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DtoLayer.Dtos.ShippingOperationDto
{
    public class UpdateShipmentOperationDto
    {
        public int ShipmentOperationId { get; set; }
        public string Barcode { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }


        public int ShipmentDetailId { get; set; }
    }
}
