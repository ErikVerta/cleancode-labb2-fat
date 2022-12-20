using Microsoft.EntityFrameworkCore;
using OrderApi.DAL;
using OrderApi.DAL.Repositories;

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
            if(await databaseContext.Orders.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Orders.Add(
                    new Order()
                    {
                        OrderDate = DateTime.Now,
                        Pizzas = new List<Pizza>
                        {
                            new Pizza()
                            {
                                Name = "Vesuvio",
                                Price = 100
                            }
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
            var order = new Order()
            {
                OrderDate = DateTime.Now,
                Pizzas = new List<Pizza>
                {
                    new Pizza()
                    {
                        Name = "Kebab",
                        Price = 110
                    }
                }
            };
            var dbContext = await GetDbContext();
            var repository = new OrderRepository(dbContext);

            // Act
            var response = await repository.AddOrderAsync(order);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Order>(response);
        }
    }
}
