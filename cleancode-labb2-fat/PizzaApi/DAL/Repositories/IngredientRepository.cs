using Microsoft.EntityFrameworkCore;
using PizzaApi.Interfaces;
using Shared;

namespace PizzaApi.DAL.Repositories
{
    
    public class IngredientRepository : IIngredientRepository
    {
        private readonly PizzaContext _context;

        public IngredientRepository(PizzaContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _context.Ingredients.Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
