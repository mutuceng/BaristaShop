using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand:IRequest
    {
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
