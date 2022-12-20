using IngredientApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace IngredientApi.DAL.Repositories
{
    
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IngredientContext _context;
        public IngredientRepository(IngredientContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;


        }

        public Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
