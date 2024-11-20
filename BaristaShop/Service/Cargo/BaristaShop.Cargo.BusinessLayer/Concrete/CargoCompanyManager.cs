using AutoMapper;
using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.DataAccessLayer.Abstract;
using BaristaShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task BDeleteAsync(int id)
        {
           await _cargoCompanyDal.DeleteAsync(id);
        }

        public async Task<List<CargoCompany>> BGetAllAsync()
        {
            var list = await _cargoCompanyDal.GetAllAsync();
            return list;

        }

        public async Task<CargoCompany> BGetByIdAsync(int id)
        {
            var company = await _cargoCompanyDal.GetByIdAsync(id);
            return company;
        }

        public async Task BInsertAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.InsertAsync(entity);
        }

        public async Task BUpdateAsync(CargoCompany entity)
        {
            
           await _cargoCompanyDal.UpdateAsync(entity);
        }
    }
}
