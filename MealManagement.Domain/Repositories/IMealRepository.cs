using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealManagement.Domain.DomainEntities;
namespace MealManagement.Domain.Repositories
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetAllMealsAsync();
        Task<Meal> GetMealByIdAsync(int mealId);
        Task<Meal> AddMealAsync(Meal meal);
        Task<bool> UpdateMealAsync(Meal meal);
        Task<bool> DeleteMealAsync(int mealId);
    }
}
