using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyListAsync()
        {
            var companies = await _cargoCompanyService.BGetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCompany(int id)
        {
            var company = await _cargoCompanyService.BGetByIdAsync(id);
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.BDeleteAsync(id);
            return Ok("Successfully deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var entity = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            await _cargoCompanyService.BInsertAsync(entity);
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var entity = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            await _cargoCompanyService.BUpdateAsync(entity);
            return Ok("Successfully updated.");
        }

    }
}
