using Microsoft.EntityFrameworkCore;
using Shared;

namespace OrderApi.DAL
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions options) : base(options)
        {

        }
    }
}
