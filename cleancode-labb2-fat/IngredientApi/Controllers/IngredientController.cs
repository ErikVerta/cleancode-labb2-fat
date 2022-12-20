using IngredientApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace IngredientApi.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IngredientController(IIngredientRepository ingredientrepository, IHttpContextAccessor httpContextAccessor)
        {
            _ingredientRepository = ingredientrepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
