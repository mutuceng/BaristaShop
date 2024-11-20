using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingDetailDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentDetailController : ControllerBase
    {
        private readonly IShipmentDetailService _shipmentDetailService;
        private readonly IMapper _mapper;

        public ShipmentDetailController(IShipmentDetailService shipmentDetailService, IMapper mapper)
        {
            _shipmentDetailService = shipmentDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ShipmentDetailListAsync()
        {
            var shipmentDetails = await _shipmentDetailService.BGetAllAsync();
            return Ok(shipmentDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdShipmentDetail(int id)
        {
            var shipmentDetail = await _shipmentDetailService.BGetByIdAsync(id);
            return Ok(shipmentDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentDetail(int id)
        {
            await _shipmentDetailService.BDeleteAsync(id);
            return Ok("Successfully deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipmentDetail(CreateShipmentDetailDto createShipmentDetailDto)
        {
            var entity = _mapper.Map<ShipmentDetail>(createShipmentDetailDto);
            await _shipmentDetailService.BInsertAsync(entity);
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShipmentDetail(UpdateShipmentDetailDto updateShipmentDetailDto)
        {
            var entity = _mapper.Map<ShipmentDetail>(updateShipmentDetailDto);
            await _shipmentDetailService.BUpdateAsync(entity);
            return Ok("Successfully updated.");
        }
    }
}
