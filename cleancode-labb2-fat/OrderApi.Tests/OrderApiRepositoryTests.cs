using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using OrderApi.DAL;
using OrderApi.DAL.Repositories;
using Shared;

namespace OrderApi.Tests
{
    public class OrderApiRepositoryTests
    {
        private readonly OrderContext _orderContext;

        public OrderApiRepositoryTests()
        {
            _orderContext = A.Fake<OrderContext>();
        }

        [Fact]
        public async Task OrderRepository_GetAllOrdersAsync_ReturnsListOfOrderObjects()
        {
            // Arrange
            var fakeDbSet = A.Fake<DbSet<Order>>();
            var repository = new OrderRepository(_orderContext);
            A.CallTo(() => _orderContext.Orders).Returns(fakeDbSet);

            // Act
            var response = await repository.GetAllOrdersAsync();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response.FirstOrDefault());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task OrderRepository_GetOrderByIdAsync_ReturnsOrderObject(int id)
        {
            // Arrange
            var fakeDbSet = A.Fake<DbSet<Order>>();
            var repository = new OrderRepository(_orderContext);
            A.CallTo(() => _orderContext.Orders).Returns(fakeDbSet);

            // Act
            var response = await repository.GetOrderByIdAsync(id);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response);
        }

        [Fact]
        public async Task OrderRepository_AddOrderAsync_ReturnsOrderObject()
        {
            // Arrange
            var fakeDbSet = A.Fake<DbSet<Order>>();
            var dummy = A.Dummy<Order>();
            var repository = new OrderRepository(_orderContext);
            A.CallTo(() => _orderContext.Orders).Returns(fakeDbSet);
            A.CallTo(() => fakeDbSet.AddAsync(A<Order>.Ignored)).Returns(dummy);

            // Act
            var response = await repository.AddOrderAsync(dummy);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response);
        }
    }
}
