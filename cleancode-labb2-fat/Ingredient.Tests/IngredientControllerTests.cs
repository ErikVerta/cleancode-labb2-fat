using Azure;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Controllers;
using PizzaApi.Interfaces;
using Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ingredient.Tests
{
    public class IngredientControllerTests
    {

        private IngredientController _ingredientController;
        private IIngredientRepository _ingredientRepository;

        public IngredientControllerTests()
        {
            //Dependencies
            _ingredientRepository = A.Fake<IIngredientRepository>();

            //SUT
            _ingredientController = new IngredientController(_ingredientRepository);
        }

        [Fact]
        public async Task IngredientController_GetAllIngredientsAsync_ReturnsOk()
        {
            //Arrange
            var ingredients = A.Fake<List<Shared.Ingredient>>();
            A.CallTo(() => _ingredientRepository.GetAllIngredientsAsync()).Returns(ingredients);

            //Act
            var response = await _ingredientController.GetAllIngredientsAsync();
            var result = (response as OkObjectResult);
            var value = (result.Value as IEnumerable<Shared.Ingredient>);

            //Assert
            result.Should().NotBe(null);
            result.Value.Should().NotBe(null);
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task IngredientController_GetIngredientByIdAsync_ReturnsOk()
        {
            //Arrange
            var id = 1;
            var ingredient = A.Fake<Shared.Ingredient>();
            A.CallTo(() => _ingredientRepository.GetIngredientByIdAsync(id));

            //Act
            var response = await _ingredientController.GetIngredientByIdAsync(id);
            var result = (response as OkObjectResult);
            var value = (result.Value as Shared.Ingredient);

            //Assert
            result.Should().NotBe(null);
            result.Value.Should().NotBe(null);
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task IngredientController_AddIngredientAsync_ReturnsOk()
        {
            // Arrange
            var dummy = A.Dummy<Shared.Ingredient>();
            var controller = new IngredientController(_ingredientRepository);
            A.CallTo(() => _ingredientRepository.AddIngredientAsync(A<Shared.Ingredient>.Ignored)).Returns(dummy);
            A.CallTo(() => _ingredientRepository.GetIngredientByIdAsync(A<int>.Ignored)).Returns<Shared.Ingredient>(null);


            // Act
            var response = await controller.AddIngredientAsync(dummy);
            var result = (response as OkObjectResult);
            var value = (result.Value as Shared.Ingredient);

            // Assert
            result.Should().NotBe(null);
            result.Value.Should().NotBe(null);
            result.StatusCode.Should().Be(200);
        }
    }
}
