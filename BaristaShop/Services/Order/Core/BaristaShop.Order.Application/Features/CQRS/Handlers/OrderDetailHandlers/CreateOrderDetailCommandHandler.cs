using BaristaShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using BaristaShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductName = command.ProductName,
                ProductId = command.ProductId,
                ProductAmount = command.ProductAmount,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId,

            });

            
        }
    }
}
