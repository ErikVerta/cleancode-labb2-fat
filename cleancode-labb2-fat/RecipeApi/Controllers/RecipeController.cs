using Microsoft.AspNetCore.Mvc;
using RecipeApi.Interfaces;
using Shared;

namespace RecipeApi.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeController(IRecipeRepository recipeRepo)
        {
            this.recipeRepo = recipeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> PostRecipeAsync([FromBody] Pizza recipe)
        {
            throw new NotImplementedException();
        }
    }
}
