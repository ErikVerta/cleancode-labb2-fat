using Microsoft.EntityFrameworkCore;
using Shared;

namespace IngredientApi.DAL
{
    public class IngredientContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public IngredientContext(DbContextOptions options) : base(options)
        {

        }
    }
}
