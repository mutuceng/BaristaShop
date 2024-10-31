using BaristaShop.Cargo.DataAccessLayer.Abstract;
using BaristaShop.Cargo.DataAccessLayer.Concrete;
using BaristaShop.Cargo.DataAccessLayer.Repositories;
using BaristaShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
