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
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                PhoneNumber = createAddressCommand.PhoneNumber,

                Country = createAddressCommand.Country,               
                City = createAddressCommand.City,
                District = createAddressCommand.District,

                Detail1 = createAddressCommand.Detail1,
                Detail2 = createAddressCommand.Detail2,
                Description = createAddressCommand.Description,
                ZipCode = createAddressCommand.ZipCode,

                UserId = createAddressCommand.UserId,

            });

            // CreateAsync bizden bir Address entity'si bekliyor.
            // Mapping yapmadığımız için uzun uzun yazdık.
        }
    }
}
