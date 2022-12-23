using OrderApi.DTO;
using Shared;

namespace OrderApi.Interfaces
{
    public interface IOrderRepository
    {  
        public Task<IEnumerable<Order>> GetAllOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<Order> AddOrderAsync(OrderDTO orderDto);
    }
}
