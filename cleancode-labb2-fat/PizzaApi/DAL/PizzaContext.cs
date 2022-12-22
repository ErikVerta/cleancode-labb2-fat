using Microsoft.EntityFrameworkCore;
using Shared;

namespace PizzaApi.DAL
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public PizzaContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}