using Microsoft.EntityFrameworkCore;
using RecipeApi.Interfaces;
using Shared;

namespace RecipeApi.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbContext context;

        public RecipeRepository(DbContext context)
        {
            this.context = context;
        }

        public Task<Pizza> AddRecipeAsync(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pizza>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByRecipeIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> ModifyRecipeAsync(int id, List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> UpdateRecipeAsync(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}
