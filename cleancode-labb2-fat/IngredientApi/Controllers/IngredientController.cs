using IngredientApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }


    }
}
