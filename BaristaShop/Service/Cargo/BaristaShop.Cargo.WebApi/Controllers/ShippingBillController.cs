using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingBillDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingBillController : ControllerBase
    {
        private readonly IShippingBillService _shippingBillService;
        private IMapper _mapper;

        public ShippingBillController(IShippingBillService shippingBillService, IMapper mapper)
        {
            _shippingBillService = shippingBillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ShippingBillListAsync()
        {
            var ShippingBills = await _shippingBillService.BGetAllAsync();
            return Ok(ShippingBills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdShippingBill(int id)
        {
            var ShippingBill = await _shippingBillService.BGetByIdAsync(id);
            return Ok(ShippingBill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingBill(int id)
        {
            await _shippingBillService.BDeleteAsync(id);
            return Ok("Successfully deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateShippingBill(CreateShippingBillDto createShippingBillDto)
        {
            var entity = _mapper.Map<ShippingBill>(createShippingBillDto);
            await _shippingBillService.BInsertAsync(entity);
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShipmentDetail(UpdateShippingBillDto updateShippingBillDto)
        {
            var entity = _mapper.Map<ShippingBill>(updateShippingBillDto);
            await _shippingBillService.BUpdateAsync(entity);
            return Ok("Successfully updated.");
        }
    }
}
