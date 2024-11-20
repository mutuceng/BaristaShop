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
    public class ShippingBillManager : IShippingBillService
    {
        private readonly IShippingBillDal _shippingtBillDal;

        public ShippingBillManager(IShippingBillDal shippingtBillDal)
        {
            _shippingtBillDal = shippingtBillDal;
        }

        public async Task BDeleteAsync(int id)
        {
            await _shippingtBillDal.DeleteAsync(id);
        }

        public async Task<List<ShippingBill>> BGetAllAsync()
        {
            var bills = await _shippingtBillDal.GetAllAsync();
            return bills;
        }

        public async Task<ShippingBill> BGetByIdAsync(int id)
        {
            var bill = await _shippingtBillDal.GetByIdAsync(id);
            return bill;
        }

        public async Task BInsertAsync(ShippingBill entity)
        {
            await _shippingtBillDal.InsertAsync(entity);
        }

        public async Task BUpdateAsync(ShippingBill entity)
        {
            await _shippingtBillDal.UpdateAsync(entity);
        }
    }
}
