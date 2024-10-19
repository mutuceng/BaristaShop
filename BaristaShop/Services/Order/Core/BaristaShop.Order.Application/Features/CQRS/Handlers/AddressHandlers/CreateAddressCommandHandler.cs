using BaristaShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        // Normalde domain katmanına erişemiyordu ancak bir projeye bir proje referansı ekledik

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
           _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,

            });

            // CreateAsync bizden bir Address entity'si bekliyor.
            // Mapping yapmadığımız için uzun uzun yazdık.
        }
    }
}
