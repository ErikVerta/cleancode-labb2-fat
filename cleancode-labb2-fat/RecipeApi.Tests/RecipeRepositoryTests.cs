namespace RecipeApi.Tests
{
    public class RecipeRepositoryTests
    {
        private async Task<RecipeContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RecipeContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RecipeContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Recipes.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Recipes.Add(
                    new Pizza()
                    {
                        Name = "Vesuvio",
                        Price = 100
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async Task RecipeRepository_GetAllRecipesAsync_ReturnsListOfRecipesObjects()
        {
            // Arrange
            DbContext dbContext = await GetDbContext();
            IRecipeRepository repository = new RecipeRepository(dbContext);

            // Act
            IEnumerable<Pizza> response = await repository.GetAllRecipesAsync();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response.FirstOrDefault());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(6)]
        public async Task RecipeRepository_GetRecipeByIdAsync_ReturnsRecipeObject(int id)
        {
            // Arrange
            DbContext dbContext = await GetDbContext();
            IRecipeRepository repository = new RecipeRepository(dbContext);

            // Act
            Pizza response = await repository.GetRecipeByIdAsync(id);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response);
        }

        [Fact]
        public async Task RecipeRepository_AddRecipeAsync_ReturnsRecipeObject()
        {
            // Arrange
            Pizza pizza = new()
            {
                Name = "Kebab",
                Price = 110
            };

            DbContext dbContext = await GetDbContext();
            IRecipeRepository repository = new RecipeRepository(dbContext);

            // Act
            var response = await repository.AddRecipeAsync(pizza);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Pizza>(response);
        }
    }
}
