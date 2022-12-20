using IngredientApi.DAL;
using IngredientApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shared;
using FluentAssertions;

namespace Ingredients.Tests
{
    public class IngredientRepositoryTests
    {
        //Ev behöver byta namn på DbContext
        private async Task<IngredientContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<IngredientContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new IngredientContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Ingredients.CountAsync() < 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    databaseContext.Ingredients.Add(
                        new Ingredient()
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
        public async void IngredientRepository_Add_ReturnsTrue()
        {
            //Arrange
            var ingredient = new Ingredient()
            {
                Name = "Cheese",
            };
            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = ingredientRepository.AddIngredientAsync(ingredient);

            //Assert
            //Vad ska stå efter should, ska den här returnera något, gör om till bool?
            result.Should();
        }

        [Fact]
        public async void IngredientRepository_GetByIdAsync_ReturnsIngredient()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = ingredientRepository.GetIngredientByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Ingredient>>();
        }

        [Fact]
        public async void IngredientRepository_GetAllAsync_ReturnsIngredients()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var ingredientRepository = new IngredientRepository(dbContext);

            //Act
            var result = ingredientRepository.GetIngredientByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Ingredient>>();
        }

    }
}
