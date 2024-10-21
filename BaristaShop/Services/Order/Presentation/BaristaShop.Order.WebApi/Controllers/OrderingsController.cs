using BaristaShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BaristaShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace BaristaShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            // send ile request göndiyoruz
            // send'in içerisindeki parametre IRequest'ten miras alan parametre olmalı
            // parametreye tıklarsan
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int i)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(i));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order successfully added.");
            // commend de request'ten miras alıyor cünkü createorderingcommand'tan türüyo
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new  DeleteOrderingCommand(id));
            return Ok("Order successfully deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering successfully updated.");
        }
    }
}
