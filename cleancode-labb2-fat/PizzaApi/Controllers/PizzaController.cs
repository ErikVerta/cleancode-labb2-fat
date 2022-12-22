using Microsoft.AspNetCore.Mvc;
using PizzaApi.DTO;
using PizzaApi.Interfaces;
using Shared;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepo;

        public PizzaController(IPizzaRepository PizzaRepo)
        {
            _pizzaRepo = PizzaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPizzasAsync()
        {
            var pizzas = await _pizzaRepo.GetAllPizzasAsync();
            return Ok(pizzas);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetPizzaByIdAsync(int id)
        {
            var pizza = await _pizzaRepo.GetPizzaByIdAsync(id);

            if (pizza == null)
                return BadRequest();

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> PostPizzaAsync([FromBody] PizzaDTO pizzaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var addedPizza = await _pizzaRepo.AddPizzaAsync(pizzaDto);

            if (addedPizza == null)
                return BadRequest();

            return Ok(addedPizza);
        }
    }
}
