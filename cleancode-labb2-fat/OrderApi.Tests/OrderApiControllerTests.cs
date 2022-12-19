using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Controllers;
using OrderApi.DAL;
using OrderApi.DAL.Repositories;
using OrderApi.Interfaces;
using Shared;

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
            Assert.IsType<Order>(value.FirstOrDefault());
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
            Assert.IsType<Order>(value);
        }
        [Fact]
        public async Task OrderController_PostOrderAsync_ReturnsOk()
        {
            // Arrange
            var dummy = A.Dummy<Order>();
            var controller = new OrderController(_orderRepository);
            A.CallTo(() => _orderRepository.AddOrderAsync(dummy)).Returns(dummy);

            // Act
            var response = await controller.PostOrderAsync(dummy);
            var result = (response as OkObjectResult);
            var value = (result.Value as Order);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(dummy, value);
            Assert.IsType<Order>(value);
        }
    }
}