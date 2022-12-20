using Microsoft.AspNetCore.Mvc;

namespace IngredientApi.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
