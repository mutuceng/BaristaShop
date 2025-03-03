using BaristaShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingsByUserIdQuery : IRequest<List<GetOrderingsByUserIdQueryResult>>
    {
        public string UserId { get; set; }
        public GetOrderingsByUserIdQuery(string userId)
        {
            UserId = userId;

        }
    }
}
