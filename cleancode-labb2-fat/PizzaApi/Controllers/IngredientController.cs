using PizzaApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("ingredients")]
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientController(IIngredientRepository ingredientrepository)
        {
            _ingredientRepository = ingredientrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredientsAsync()
        {
            return Ok(await _ingredientRepository.GetAllIngredientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientByIdAsync(int id)
        {
            Ingredient ingredient = await _ingredientRepository.GetIngredientByIdAsync(id);
            if (ingredient is null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientAsync([FromBody] Ingredient ingredient)
        {
            Ingredient existing = await _ingredientRepository.GetIngredientByIdAsync(ingredient.Id);
            if (existing is not null)
            {
                return Conflict();
            }

            await _ingredientRepository.AddIngredientAsync(ingredient);
            return Ok(ingredient);
        }
    }
}
