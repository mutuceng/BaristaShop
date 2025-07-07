using BaristaShop.Message.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaristaShop.Message.Context
{
    public class MessageContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost; port=5442; database=BaristaShopMessageDb; username=postgres; password=admin123D!");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
