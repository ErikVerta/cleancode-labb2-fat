using FakeItEasy;
using FluentAssertions;
using IngredientApi.Controllers;
using IngredientApi.DAL.Repositories;
using IngredientApi.Interfaces;
using Microsoft.AspNetCore.Http;
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
            //Ska inte heta index sen?
            var result = _ingredientController.Index();

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
            //Namnet från controllern där det står index
            var result = _ingredientController.Index(id);

            //Assert
            result.Should().BeOfType<Shared.Ingredient>();
        }

        [Fact]
        public void IngredientController_Add_ReturnsTrue()
        {
            //Arrange
            var ingredient = new Shared.Ingredient()
            {
                Name = "Cheese",
            };

            //Act
            
            //Assert
            
        }
    }
}
