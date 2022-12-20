using Microsoft.AspNetCore.Mvc;
using RecipeApi.Interfaces;
using Shared;

namespace RecipeApi.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipeController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepo.GetAllRecipesAsync();
            return Ok(recipes);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepo.GetRecipeByIdAsync(id);
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> PostRecipeAsync([FromBody] Pizza recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var addedRecipe = await _recipeRepo.AddRecipeAsync(recipe);
            return Ok(addedRecipe);
        }
    }
}
