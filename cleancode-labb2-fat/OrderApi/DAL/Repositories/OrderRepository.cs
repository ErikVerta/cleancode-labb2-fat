using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            if (_context.Orders.Any(p => p.Id == order.Id))
                return null;

            var addOrder = await NewOrderAsync(order);

            if (order == null)
                return null;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return addOrder;
        }

        private async Task<Order> NewOrderAsync(Order order)
        {
            var pizzas = new List<Pizza>();

            foreach (var id in order.Pizzas)
            {
                var addToOrder = await _context.Pizzas.FindAsync(id);
                if (addToOrder is null)
                    return null;
                pizzas.Add(addToOrder);
            }

            var newOrder = new Order()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Pizzas = pizzas
            };
            return newOrder;
        }
    }
}
