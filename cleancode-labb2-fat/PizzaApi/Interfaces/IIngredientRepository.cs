using Shared;

namespace PizzaApi.Interfaces
{
    public interface IIngredientRepository
    {
        public Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
        public Task<List<Ingredient>> GetAllIngredientsAsync();
        public Task<Ingredient> GetIngredientByIdAsync(int id);
        //public Task<List<Pizza>> GetPizzasByIngredientIdAsync(int id);
        //public Task<Ingredient> ModifyIngredientAsync(int id);
        //public Task<Ingredient> DeleteIngredientAsync(int id);
    }
}
