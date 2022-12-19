﻿using Shared;

namespace OrderApi.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrderAsync(Order order);
        public Task<IEnumerable<Order>> GetAllOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<Order> UpdateOrderAsync(int id, Order order);
        public Task<Order> ModifyOrderAsync(int id, List<Pizza> pizzas);
        public Task<Order> DeleteOrderAsync(int id);
    }
}