namespace RecipeApi.Tests
{
    public class RecipeControllerTests
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeControllerTests()
        {
            recipeRepo = A.Fake<IRecipeRepository>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task RecipeController_GetAllRecipeAsync_ReturnsOk(int count)
        {
            // Arrange
            IEnumerable<Pizza> dummies = A.CollectionOfDummy<Pizza>(count);
            RecipeController controller = new(recipeRepo);
            A.CallTo(() => recipeRepo.GetAllRecipesAsync()).Returns(dummies);

            // Act
            IActionResult response = await controller.GetAllRecipesAsync();
            OkObjectResult result = (response as OkObjectResult);
            IEnumerable<Pizza> value = (result.Value as IEnumerable<Pizza>);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(count, value.Count());
            Assert.IsType<Pizza>(value.FirstOrDefault());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task RecipeController_GetRecipeByIdAsync_ReturnsOk(int id)
        {
            // Arrange
            Pizza dummy = A.Dummy<Pizza>();
            RecipeController controller = new(recipeRepo);
            A.CallTo(() => recipeRepo.GetRecipeByIdAsync(id)).Returns(dummy);

            // Act
            IActionResult response = await controller.GetRecipeByIdAsync(id);
            OkObjectResult result = (response as OkObjectResult);
            Pizza value = (result.Value as Pizza);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<Pizza>(value);
        }

        [Fact]
        public async Task RecipeController_PostRecipeAsync_ReturnsOk()
        {
            // Arrange
            Pizza dummy = A.Dummy<Pizza>();
            RecipeController controller = new(recipeRepo);
            A.CallTo(() => recipeRepo.AddRecipeAsync(A<Pizza>.Ignored)).Returns(dummy);

            // Act
            IActionResult response = await controller.PostRecipeAsync(dummy);
            OkObjectResult result = (response as OkObjectResult);
            Pizza value = (result.Value as Pizza);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(dummy, value);
            Assert.IsType<Pizza>(value);
        }
    }
}