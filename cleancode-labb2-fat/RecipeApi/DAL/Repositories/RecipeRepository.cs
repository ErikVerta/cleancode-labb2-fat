using Microsoft.EntityFrameworkCore;
using RecipeApi.Interfaces;
using Shared;

namespace RecipeApi.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _context;

        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Pizza> AddRecipeAsync(Pizza pizza)
        {
            _context.Recipes.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public Task<Pizza> DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> GetAllRecipesAsync()
        {
            return _context.Recipes;
        }

        public Task<IEnumerable<Order>> GetOrdersByRecipeIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pizza> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
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
