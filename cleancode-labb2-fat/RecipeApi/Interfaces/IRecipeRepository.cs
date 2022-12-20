using Shared;

namespace RecipeApi.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<Pizza> AddRecipeAsync(Pizza pizza);
        public Task<IEnumerable<Pizza>> GetAllRecipesAsync();
        public Task<Pizza> GetRecipeByIdAsync(int id);
        public Task<IEnumerable<Order>> GetOrdersByRecipeIdAsync(int id);
        public Task<Pizza> UpdateRecipeAsync(int id, Pizza pizza);
        public Task<Pizza> ModifyRecipeAsync(int id, List<Ingredient> ingredients);
        public Task<Pizza> DeleteRecipeAsync(int id);
    }
}
