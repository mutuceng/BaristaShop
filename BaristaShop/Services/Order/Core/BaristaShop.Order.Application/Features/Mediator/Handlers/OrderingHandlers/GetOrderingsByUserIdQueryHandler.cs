using BaristaShop.Order.Application.Features.CQRS.Results.AddressResults;
using BaristaShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using BaristaShop.Order.Application.Features.Mediator.Results.OrderingResults;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingsByUserIdQueryHandler : IRequestHandler<GetOrderingsByUserIdQuery, List<GetOrderingsByUserIdQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingsByUserIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderingsByUserIdQueryResult>> Handle(GetOrderingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFiltreAsync(a => a.UserId == request.UserId);

            return values.Select(a => new GetOrderingsByUserIdQueryResult
            {
                AddressId = a.AddressId,
                OrderDate = a.OrderDate,
                OrderingId = a.OrderingId,
                TotalPrice = a.TotalPrice,
                UserId = a.UserId,
            }).ToList();
        }
    }
}
