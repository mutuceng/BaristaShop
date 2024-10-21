using BaristaShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        // yine domain katmanını ekledim
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; port=5432; Database=BaristaShopOrderDb; Username=postgres; Password=admin123D!");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings{ get; set; }
    }
}
