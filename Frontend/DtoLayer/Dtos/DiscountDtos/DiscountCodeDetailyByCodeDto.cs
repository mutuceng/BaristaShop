using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.DtoLayer.Dtos.DiscountDtos
{
    public class DiscountCodeDetailyByCodeDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
