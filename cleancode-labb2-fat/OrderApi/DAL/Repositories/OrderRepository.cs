using Microsoft.EntityFrameworkCore;
using OrderApi.DTO;
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
            var orders = _context.Orders.Include(o => o.OrderDetails);
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<Order> AddOrderAsync(OrderDTO orderDto)
        {
            var addOrder = await NewOrderAsync(orderDto);

            if (addOrder == null)
                return null;

            await _context.Orders.AddAsync(addOrder);
            await _context.SaveChangesAsync();

            return addOrder;
        }

        private async Task<Order> NewOrderAsync(OrderDTO orderDto)
        {
            if (orderDto.PizzaIds.Count() < 1)
                return null;

            var orderDetails = new List<OrderDetail>();

            foreach (var id in orderDto.PizzaIds)
            {
                var orderDetail = new OrderDetail
                {
                    PizzaId = id,
                };
                orderDetails.Add(orderDetail);
            }

            var newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                OrderDetails = orderDetails
            };
            return newOrder;
        }
    }
}
