namespace PizzaApi.Tests
{
    public class PizzaControllerTests
    {
        private readonly IPizzaRepository pizzaRepo;

        public PizzaControllerTests()
        {
            pizzaRepo = A.Fake<IPizzaRepository>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task PizzaController_GetAllPizzasAsync_ReturnsOk(int count)
        {
            // Arrange
            IEnumerable<Pizza> dummies = A.CollectionOfDummy<Pizza>(count);
            PizzaController controller = new(pizzaRepo);
            A.CallTo(() => pizzaRepo.GetAllPizzasAsync()).Returns(dummies);

            // Act
            IActionResult response = await controller.GetAllPizzasAsync();
            OkObjectResult result = (response as OkObjectResult);
            IEnumerable<Pizza> value = (result.Value as IEnumerable<Pizza>);

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
        public async Task PizzaController_GetPizzaByIdAsync_ReturnsOk(int id)
        {
            // Arrange
            Pizza dummy = A.Dummy<Pizza>();
            PizzaController controller = new(pizzaRepo);
            A.CallTo(() => pizzaRepo.GetPizzaByIdAsync(id)).Returns(dummy);

            // Act
            IActionResult response = await controller.GetPizzaByIdAsync(id);
            OkObjectResult result = (response as OkObjectResult);
            Pizza value = (result.Value as Pizza);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PizzaController_PostPizzaAsync_ReturnsOk()
        {
            // Arrange
            Pizza dummy = A.Dummy<Pizza>();
            PizzaDTO dummyDto = A.Dummy<PizzaDTO>();
            PizzaController controller = new(pizzaRepo);
            A.CallTo(() => pizzaRepo.AddPizzaAsync(A<PizzaDTO>.Ignored)).Returns(dummy);

            // Act
            IActionResult response = await controller.PostPizzaAsync(dummyDto);
            OkObjectResult result = (response as OkObjectResult);
            Pizza value = (result.Value as Pizza);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(dummy, value);
        }
    }
}