using Shared;

namespace RecipeApi.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<Pizza> AddRecipeAsync(Pizza pizza);
        public Task<List<Pizza>> GetAllRecipesAsync();
        public Task<Pizza> GetRecipeByIdAsync(int id);
        public Task<List<Order>> GetOrdersByRecipeIdAsync(int id);
        public Task<Pizza> UpdateRecipeAsync(int id, Pizza pizza);
        public Task<Pizza> ModifyRecipeAsync(int id, List<Ingredient> ingredients);
        public Task<Pizza> DeleteRecipeAsync(int id);
    }
}
