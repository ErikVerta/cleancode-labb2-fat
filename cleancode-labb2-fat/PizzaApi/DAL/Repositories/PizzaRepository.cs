using Microsoft.EntityFrameworkCore;
using PizzaApi.DTO;
using PizzaApi.Interfaces;
using Shared;

namespace PizzaApi.DAL.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext _context;

        public PizzaRepository(PizzaContext context)
        {
            _context = context;
        }

        public async Task<Pizza> AddPizzaAsync(PizzaDTO pizzaDto)
        {
            if (_context.Pizzas.Any(p => p.Name == pizzaDto.Name))
                 return null;
            
            var pizza = await BuildPizzaObjectAsync(pizzaDto);
            
            if (pizza == null)
                return null;

            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }
  
        public async Task<IEnumerable<Pizza>> GetAllPizzasAsync()
        {
            return _context.Pizzas.Include(p => p.Ingredients);
        }
    
        public async Task<Pizza> GetPizzaByIdAsync(int id)  
        {
            return await _context.Pizzas
                .Include(p => p.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        private async Task<Pizza> BuildPizzaObjectAsync(PizzaDTO pizzaDto)
        {
            var ingredients = new List<Ingredient>();

            foreach (var id in pizzaDto.IngredientIds)
            {
                var ingredient = await _context.Ingredients.FindAsync(id);
                if (ingredient is null)
                    return null;
                ingredients.Add(ingredient);
            }

            var pizza = new Pizza() 
            {
                Name = pizzaDto.Name,
                Price = pizzaDto.Price,
                Ingredients = ingredients
            };
            return pizza;
        }
    }
}
