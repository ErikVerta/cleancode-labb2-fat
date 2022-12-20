using FakeItEasy;
using FluentAssertions;
using IngredientApi.Controllers;
using IngredientApi.DAL.Repositories;
using IngredientApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ingredient.Tests
{
    public class IngredientControllerTests
    {

        private IngredientController _ingredientController;
        private IIngredientRepository _ingredientRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public IngredientControllerTests()
        {
            //Dependencies
            _ingredientRepository = A.Fake<IIngredientRepository>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _ingredientController = new IngredientController(_ingredientRepository, _httpContextAccessor);
        }

        [Fact]
        public void IngredientController_GetAllIngredientsAsync_ReturnsIngredients()
        {
            //Arrange
            var ingredients = A.Fake<List<Shared.Ingredient>>();
            A.CallTo(() => _ingredientRepository.GetAllIngredientsAsync()).Returns(ingredients);

            //Act
            var result = _ingredientController.GetAllIngredientsAsync();

            //Assert
            result.Should().BeOfType<List<Shared.Ingredient>>();
        }

        [Fact]
        public void IngredientController_GetIngredientById_ReturnsIngredient()
        {
            //Arrange
            var id = 1;
            var ingredient = A.Fake<Shared.Ingredient>();
            A.CallTo(() => _ingredientRepository.GetIngredientByIdAsync(id));

            //Act
            var result = _ingredientController.GetIngredientByIdAsync(id);

            //Assert
            result.Should().BeOfType<Shared.Ingredient>();
        }

        [Fact]
        public async Task IngredientController_Add_ReturnsOk()
        {
            // Arrange
            var dummy = A.Dummy<Shared.Ingredient>();
            var controller = new IngredientController(_ingredientRepository, _httpContextAccessor);
            A.CallTo(() => _ingredientRepository.AddIngredientAsync(A<Shared.Ingredient>.Ignored)).Returns(dummy);

            // Act
            var response = await controller.AddIngredientAsync(dummy);
            var result = (response as OkObjectResult);
            var value = (result.Value as Shared.Ingredient);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(dummy, value);
            Assert.IsType<Shared.Ingredient>(value);

        }
    }
}
