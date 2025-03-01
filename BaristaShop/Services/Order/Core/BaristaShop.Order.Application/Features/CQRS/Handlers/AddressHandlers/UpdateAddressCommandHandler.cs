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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressId);
            value.AddressId = command.AddressId;
            value.Name = command.Name;
            value.Surname = command.Surname;
            value.PhoneNumber = command.PhoneNumber;

            value.Country = command.Country;
            value.District = command.District;
            value.City = command.City;

            value.Detail1 = command.Detail1;
            value.Detail2 = command.Detail2;
            value.Description = command.Description;
            value.ZipCode = command.ZipCode;

            value.UserId = command.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
