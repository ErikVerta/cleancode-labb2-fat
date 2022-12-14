using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using PizzaApi.DAL;
using PizzaApi.DAL.Repositories;

namespace Ingredients.Tests
{
    public class IngredientRepositoryTests
    {
        //Ev behöver byta namn på DbContext
        private async Task<PizzaContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new PizzaContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Ingredients.CountAsync() < 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    databaseContext.Ingredients.Add(
                        new Shared.Ingredient()
                        {
                            Id = i,
                            Name = "Cheese",
                        });
                    await databaseContext.SaveChangesAsync();
                }
            } 
            return databaseContext;
        }

        [Fact]
        public async void IngredientRepository_GetAllIngredientsAsync_ReturnsIngredients()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = ingredientRepository.GetAllIngredientsAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<Shared.Ingredient>>>();
        }

        [Fact]
        public async void IngredientRepository_GetIngredientByIdAsync_ReturnsIngredient()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = ingredientRepository.GetIngredientByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Shared.Ingredient>>();
        }

        [Fact]
        public async void IngredientRepository_AddIngredientAsync_Returns()
        {
            //Arrange
            var ingredient = new Shared.Ingredient()
            {
                Name = "Cheese",
            };

            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = await ingredientRepository.AddIngredientAsync(ingredient);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Shared.Ingredient>(result);
        }

    }
}
