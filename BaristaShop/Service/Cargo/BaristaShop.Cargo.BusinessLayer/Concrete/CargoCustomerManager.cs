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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task BDeleteAsync(int id)
        {
            await _cargoCustomerDal.DeleteAsync(id);
        }

        public async Task<List<CargoCustomer>> BGetAllAsync()
        {
            var customers = await _cargoCustomerDal.GetAllAsync();
            return customers;
        }

        public async Task<CargoCustomer> BGetByIdAsync(int id)
        {
            var customer = await _cargoCustomerDal.GetByIdAsync(id);
            return customer;
        }

        public async Task BInsertAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.InsertAsync(entity);
        }

        public async Task BUpdateAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.UpdateAsync(entity);
        }
    }
}
