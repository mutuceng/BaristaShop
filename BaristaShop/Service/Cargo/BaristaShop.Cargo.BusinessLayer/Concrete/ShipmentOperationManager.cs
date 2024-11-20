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
    public class ShipmentOperationManager : IShipmentOperationService
    {
        private readonly IShipmentOperationDal _shipmentOperationDal;

        public ShipmentOperationManager(IShipmentOperationDal shipmentOperationDal)
        {
            _shipmentOperationDal = shipmentOperationDal;
        }

        public async Task BDeleteAsync(int id)
        {
            await _shipmentOperationDal.DeleteAsync(id);
        }

        public async Task<List<ShipmentOperation>> BGetAllAsync()
        {
            var operationLists = await _shipmentOperationDal.GetAllAsync();
            return operationLists;
        }

        public async Task<ShipmentOperation> BGetByIdAsync(int id)
        {
            var operation = await _shipmentOperationDal.GetByIdAsync(id);
            return operation;
        }

        public async Task BInsertAsync(ShipmentOperation entity)
        {
            await _shipmentOperationDal.InsertAsync(entity);
        }

        public async Task BUpdateAsync(ShipmentOperation entity)
        {
            await _shipmentOperationDal.UpdateAsync(entity);
        }
    }
}
