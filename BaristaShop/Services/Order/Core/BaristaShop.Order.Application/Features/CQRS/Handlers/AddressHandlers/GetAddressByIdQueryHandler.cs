using BaristaShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using BaristaShop.Order.Application.Features.CQRS.Results.AddressResults;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                Name = value.Name,
                Surname = value.Surname,
                PhoneNumber = value.PhoneNumber,

                Country = value.Country,
                District = value.District,
                City = value.City,

                Detail1 = value.Detail1,
                Detail2 = value.Detail2,
                Description = value.Description,
                ZipCode = value.ZipCode,

                UserId = value.UserId,
            };
        }

        // Burada bir değer döndürmek zorunda olduğumu için Task< > oldu.
        // Task içinde ne döndüreceğimizi belirttik

    }
}
