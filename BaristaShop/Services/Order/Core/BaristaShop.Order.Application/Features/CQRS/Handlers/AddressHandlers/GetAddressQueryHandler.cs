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
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,

                Country = x.Country,
                City = x.City,
                District = x.District,

                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Description = x.Description,
                ZipCode = x.ZipCode,

                UserId = x.UserId,
            }).ToList();

            // eğer ToList() kullanmazsan (List<GetAddressQueryResult>)values.Selec
        }
    }
}
