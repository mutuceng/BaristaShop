using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByUserIdQuery
    {
        public string UserId { get; set; }
        public GetAddressByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
