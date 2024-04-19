using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost()]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddMeal([FromBody] MealDto mealDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mealInserted = await _mealService.AddMealAsync(mealDto);
                return Ok(mealInserted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the meal.");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _mealService.GetAllAvaliableMeals();
            return Ok(meals);
        }

        [HttpDelete("{mealId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var success = await _mealService.DeleteMealAsync(mealId);
            if (!success)
            {
                return NotFound("Meal not found.");
            }
            return Ok("Alimento Eliminada correctamente");
        }

        [HttpPut("{mealId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateMeal(int mealId, [FromBody] MealUpdateDto mealDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mealDto.IdMeal = mealId;
            var success = await _mealService.UpdateMealAsync(mealDto);
            if (!success)
            {
                return NotFound("Meal not found or update failed.");
            }
            return Ok("Alimento Actualizado correctamente");
        }

    }
}