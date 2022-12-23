namespace PizzaApi.Tests
{
    public class PizzaRepositoryTests
    {
        private async Task<PizzaContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new PizzaContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Pizzas.CountAsync() < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Pizzas.Add(
                    new Pizza()
                    {
                        Name = "Vesuvio",
                        Price = 100,
                        Ingredients = new List<Ingredient>
                        {
                            new Ingredient() {Name = "Cheese"}
                        }
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async Task PizzaRepository_GetAllPizzasAsync_ReturnsListOfPizzaObjects()
        {
            // Arrange
            PizzaContext dbContext = await GetDbContext();
            IPizzaRepository repository = new PizzaRepository(dbContext);

            // Act
            IEnumerable<Pizza> response = await repository.GetAllPizzasAsync();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response.FirstOrDefault());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(6)]
        public async Task PizzaRepository_GetPizzaByIdAsync_ReturnsPizzaObject(int id)
        {
            // Arrange
            PizzaContext dbContext = await GetDbContext();
            IPizzaRepository repository = new PizzaRepository(dbContext);

            // Act
            Pizza response = await repository.GetPizzaByIdAsync(id);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response);
        }

        [Fact]
        public async Task PizzaRepository_AddPizzaAsync_ReturnsPizzaObject()
        {
            // Arrange
            PizzaDTO pizzaDto = new()
            {
                Name = "Kebab",
                Price = 110,
                IngredientIds = new int[] {1}
            };

            PizzaContext dbContext = await GetDbContext();
            IPizzaRepository repository = new PizzaRepository(dbContext);

            // Act
            var response = await repository.AddPizzaAsync(pizzaDto);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response);
        }
    }
}
