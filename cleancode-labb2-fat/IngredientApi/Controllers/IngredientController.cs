﻿using IngredientApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace IngredientApi.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IngredientController(IIngredientRepository ingredientrepository, IHttpContextAccessor httpContextAccessor)
        {
            _ingredientRepository = ingredientrepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IActionResult> GetAllIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetIngredientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> AddIngredientAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
