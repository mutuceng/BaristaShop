using BaristaShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using BaristaShop.Order.Application.Features.CQRS.Results.AddressResults;
using BaristaShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = value.OrderDetailId,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductAmount = value.ProductAmount,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderingId = value.OrderingId,

            };
            
        }
    }
}
