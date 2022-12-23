using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Controllers;
using OrderApi.DTO;
using OrderApi.Interfaces;

namespace OrderApi.Tests
{
    public class OrderApiControllerTests
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApiControllerTests()
        {
            _orderRepository = A.Fake<IOrderRepository>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task OrderController_GetAllOrdersAsync_ReturnsOk(int count)
        {
            // Arrange
            var dummies = A.CollectionOfDummy<Order>(count);
            var controller = new OrderController(_orderRepository);
            A.CallTo(() => _orderRepository.GetAllOrdersAsync()).Returns(dummies);

            // Act
            var response = await controller.GetAllOrdersAsync();
            var result = (response as OkObjectResult);
            var value = (result.Value as IEnumerable<Order>);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(count, value.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task OrderController_GetOrderByIdAsync_ReturnsOk(int id)
        {
            // Arrange
            var dummy = A.Dummy<Order>();
            var controller = new OrderController(_orderRepository);
            A.CallTo(() => _orderRepository.GetOrderByIdAsync(id)).Returns(dummy);

            // Act
            var response = await controller.GetOrderByIdAsync(id);
            var result = (response as OkObjectResult);
            var value = (result.Value as Order);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task OrderController_PostOrderAsync_ReturnsOk()
        {
            // Arrange
            var dummy = A.Dummy<Order>();
            var dummyDto = A.Dummy<OrderDTO>();
            var controller = new OrderController(_orderRepository);
            A.CallTo(() => _orderRepository.AddOrderAsync(A<OrderDTO>.Ignored)).Returns(dummy);

            // Act
            var response = await controller.PostOrderAsync(dummyDto);
            var result = (response as OkObjectResult);
            var value = (result.Value as Order);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(dummy, value);
        }
    }
}