using MealManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MealManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _mealService.GetAllAvaliableMeals();
            return Ok(meals);
        }
    }
}
