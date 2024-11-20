using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCostumerDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {

        // lets make this api more secure

        private readonly ICargoCompanyService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomerController(ICargoCompanyService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomerListAsync()
        {
            var customers = await _cargoCustomerService.BGetAllAsync();
            var dtoCustomers = _mapper.Map<List<ResultCargoCustomerDto>>(customers);
            return Ok(dtoCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCustomerGetById(int id)
        {
            var customer = await _cargoCustomerService.BGetByIdAsync(id);
            var dtoCustomer = _mapper.Map<List<GetByIdCargoCustomerDto>>(customer);
            return Ok(dtoCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _cargoCustomerService.BDeleteAsync(id);
            return Ok("Successfully deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCostumer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var entity = _mapper.Map<CargoCompany>(createCargoCustomerDto);
            await _cargoCustomerService.BInsertAsync(entity);
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> UpateCargoCostumer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var entity = _mapper.Map<CargoCompany>(updateCargoCustomerDto);
            await _cargoCustomerService.BUpdateAsync(entity);
            return Ok("Successfully updated");
        }


    }
}
