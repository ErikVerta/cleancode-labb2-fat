using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Shared;

namespace OrderApi.DAL
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public OrderContext(DbContextOptions options) : base(options)
        {
            try
            {
                RelationalDatabaseCreator creator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (creator is null)
                {
                    return;
                }

                if (!creator.CanConnect())
                {
                    creator.Create();
                }
                if (!creator.HasTables())
                {
                    creator.CreateTables();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
