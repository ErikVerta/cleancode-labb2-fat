using Shared;

namespace IngredientApi.Interfaces
{
    public interface IIngredientService
    {
        public Task<Ingredient> AddIngredientAsync();
        public Task<List<Ingredient>> GetAllIngredientsAsync();
        public Task<Ingredient> GetIngredientByIdAsync(int id);
        public Task<List<Recipe>> GetRecipesByIngredientIdAsync(int id);
        public Task<Ingredient> ModifyIngredientAsync(int id);
        public Task<Ingredient> DeleteIngredientAsync(int id);
    }
}
