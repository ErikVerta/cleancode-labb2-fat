using Microsoft.EntityFrameworkCore;
using OrderApi.DAL;
using OrderApi.DAL.Repositories;
using OrderApi.DTO;

namespace OrderApi.Tests
{
    public class OrderApiRepositoryTests
    {
        private async Task<OrderContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new OrderContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Orders.CountAsync() < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Orders.Add(
                    new Order()
                    {
                        OrderDate = DateTime.Now,
                        OrderDetails = new List<OrderDetail> 
                        { 
                            new OrderDetail{PizzaId = i}
                        } 
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async Task OrderRepository_GetAllOrdersAsync_ReturnsListOfOrderObjects()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var repository = new OrderRepository(dbContext);

            // Act
            var response = await repository.GetAllOrdersAsync();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response.FirstOrDefault());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(6)]
        public async Task OrderRepository_GetOrderByIdAsync_ReturnsOrderObject(int id)
        {
            // Arrange
            var dbContext = await GetDbContext();
            var repository = new OrderRepository(dbContext);

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
            var orderDto = new OrderDTO 
            { 
                PizzaIds = new List<int> { 1,2,3 }
            };

            var dbContext = await GetDbContext();
            var repository = new OrderRepository(dbContext);

            // Act
            var response = await repository.AddOrderAsync(orderDto);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response);
        }
    }
}
