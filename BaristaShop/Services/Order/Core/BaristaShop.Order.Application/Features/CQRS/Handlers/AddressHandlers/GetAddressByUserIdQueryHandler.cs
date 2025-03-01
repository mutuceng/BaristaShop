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
    public class GetAddressByUserIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByUserIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressByUserIdQueryResult>> Handle(GetAddressByUserIdQuery query)
        {
            var values = await _repository.GetByFiltreAsync(a => a.UserId == query.UserId);

            return values.Select(a => new GetAddressByUserIdQueryResult
            {
                AddressId = a.AddressId,
                Name = a.Name,
                Surname = a.Surname,
                PhoneNumber = a.PhoneNumber,
                Country = a.Country,
                District = a.District,
                City = a.City,
                Detail1 = a.Detail1,
                Detail2 = a.Detail2,
                Description = a.Description,
                ZipCode = a.ZipCode,
                UserId = a.UserId,
            }).ToList();
        }
    }
}
