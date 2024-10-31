using BaristaShop.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,5441; initial catalog=BaristaShopCargoDb; user=sa; password=admin123D!; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<CargoCompany> CargoCompanies { get; set; }
        DbSet<CargoCustomer> CargoCustomers { get; set; }
        DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        DbSet<ShipmentOperation> ShipmentOperations { get; set; }
        DbSet<ShippingBill> ShippingBills { get; set; }

        //migration'da proje olarak webapi'ı seçiyorsun ama package manage console'da access data layerı



    }
}
