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
    public class ShipmentDetailManager : IShipmentDetailService
    {
        private readonly IShipmentDetailDal _shipmentDetailDal;

        public ShipmentDetailManager(IShipmentDetailDal shipmentDetailDal)
        {
            _shipmentDetailDal = shipmentDetailDal;
        }

        public async Task BDeleteAsync(int id)
        {
            await _shipmentDetailDal.DeleteAsync(id);
        }

        public async Task<List<ShipmentDetail>> BGetAllAsync()
        {
            var shipmentDetailList = await _shipmentDetailDal.GetAllAsync();
            return shipmentDetailList;
        }

        public async Task<ShipmentDetail> BGetByIdAsync(int id)
        {
            var shipmentDetail = await _shipmentDetailDal.GetByIdAsync(id); 
            return shipmentDetail;
        }

        public async Task BInsertAsync(ShipmentDetail entity)
        {
            await _shipmentDetailDal.InsertAsync(entity);
        }

        public async Task BUpdateAsync(ShipmentDetail entity)
        {
            await _shipmentDetailDal.UpdateAsync(entity);
        }
    }
}
