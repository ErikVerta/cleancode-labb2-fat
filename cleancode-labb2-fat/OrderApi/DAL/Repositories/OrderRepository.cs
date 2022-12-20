using OrderApi.Interfaces;
using Shared;

namespace OrderApi.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> ModifyOrderAsync(int id, List<Pizza> pizzas)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
