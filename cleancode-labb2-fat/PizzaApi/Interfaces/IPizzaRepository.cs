using PizzaApi.DTO;
using Shared;

namespace PizzaApi.Interfaces
{
    public interface IPizzaRepository
    {
        public Task<Pizza> AddPizzaAsync(PizzaDTO pizzaDto);
        public Task<IEnumerable<Pizza>> GetAllPizzasAsync();
        public Task<Pizza> GetPizzaByIdAsync(int id);
        //public Task<IEnumerable<Order>> GetOrdersByPizzaIdAsync(int id);
        //public Task<Pizza> UpdatePizzaAsync(int id, Pizza pizza);
        //public Task<Pizza> ModifyPizzaAsync(int id, List<Ingredient> ingredients);
        //public Task<Pizza> DeletePizzaAsync(int id);
    }
}
