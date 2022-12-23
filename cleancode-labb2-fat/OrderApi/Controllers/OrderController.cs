using Microsoft.AspNetCore.Mvc;
using OrderApi.DTO;
using OrderApi.Interfaces;
using Shared;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("orders")]
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
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
                return BadRequest();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync([FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newOrder = await _orderRepository.AddOrderAsync(orderDto);

            if (newOrder == null)
                return BadRequest();

            return Ok(newOrder);
        }
    }
}
