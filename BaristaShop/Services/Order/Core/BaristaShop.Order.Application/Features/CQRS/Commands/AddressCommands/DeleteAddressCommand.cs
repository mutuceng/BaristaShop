using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public int Id { get; set; }
        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
    }
}
