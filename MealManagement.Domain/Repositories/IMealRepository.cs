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
        Task AddMealAsync(Meal meal);
        Task UpdateMealAsync(Meal meal);
        Task DeleteMealAsync(int mealId);
    }
}
