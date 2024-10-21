using BaristaShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BaristaShop.Order.Application.Interfaces;
using BaristaShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class DeleteOrderingCommandHandler:IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
