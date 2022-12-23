using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Shared;

namespace PizzaApi.DAL
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public PizzaContext(DbContextOptions options)
            : base(options)
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