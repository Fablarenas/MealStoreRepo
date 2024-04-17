using MealManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Application.Interfaces
{
    public interface IMealService
    {
        Task<List<MealDto>> GetAllAvaliableMeals();
        Task<MealDto> GetMealByIdAsync(int mealId);
        Task AddMealAsync(MealDto mealDto);
        Task UpdateMealAsync(MealDto mealDto);
        Task DeleteMealAsync(int mealId);
    }
}
