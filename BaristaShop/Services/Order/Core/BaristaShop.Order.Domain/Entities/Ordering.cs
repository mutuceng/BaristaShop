using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
