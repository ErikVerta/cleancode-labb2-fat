using Microsoft.EntityFrameworkCore;
using Shared;

namespace RecipeApi.DAL
{
    public class RecipeContext : DbContext
    {
        public DbSet<Pizza> Recipes { get; set; }

        public RecipeContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
