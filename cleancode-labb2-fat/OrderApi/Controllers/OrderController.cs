using Microsoft.AspNetCore.Mvc;
using OrderApi.Interfaces;
using Shared;

namespace OrderApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync([FromBody] Order order)
        {
            throw new NotImplementedException();
        }
    }
}
