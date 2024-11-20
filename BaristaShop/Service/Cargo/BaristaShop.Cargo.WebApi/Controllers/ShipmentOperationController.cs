using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingDetailDto;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingOperationDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentOperationController : ControllerBase
    {
        private readonly IShipmentOperationService _shipmentOperationService;
        private readonly IMapper _mapper;

        public ShipmentOperationController(IShipmentOperationService shipmentOperationService, IMapper mapper)
        {
            _shipmentOperationService = shipmentOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ShipmentOperationListAsync()
        {
            var shipmentOperations = await _shipmentOperationService.BGetAllAsync();
            return Ok(shipmentOperations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdShipmentOperation(int id)
        {
            var shipmentOperation = await _shipmentOperationService.BGetByIdAsync(id);
            return Ok(shipmentOperation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentOperation(int id)
        {
            await _shipmentOperationService.BDeleteAsync(id);
            return Ok("Successfully deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipmentOperation(CreateShipmentOperationDto createShipmentOperationDto)
        {
            var entity = _mapper.Map<ShipmentOperation>(createShipmentOperationDto);
            await _shipmentOperationService.BInsertAsync(entity);
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShipmentDetail(UpdateShipmentOperationDto updateShipmentOperationDto)
        {
            var entity = _mapper.Map<ShipmentOperation>(updateShipmentOperationDto);
            await _shipmentOperationService.BUpdateAsync(entity);
            return Ok("Successfully updated.");
        }
    }
}
