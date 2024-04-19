using AutoMapper;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;
using MealManagement.Infraestructure.DbContext;
using MealManagement.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace MealManagement.Infraestructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly MealStoreContext _context;
        private readonly IMapper _mapper;
        public MealRepository(MealStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Meal> AddMealAsync(Meal meal)
        {
            var mealEntity = _mapper.Map<MealEntity>(meal);

            _context.Meals.Add(mealEntity);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return _mapper.Map<Meal>(mealEntity);
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> DeleteMealAsync(int mealId)
        {
            var mealEntity = await _context.Meals.FindAsync(mealId);
            if (mealEntity == null)
            {
                return false;
            }

            _context.Meals.Remove(mealEntity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Meal>> GetAllMealsAsync()
        {
            var meals = await _context.Meals.ToListAsync();
            return _mapper.Map<List<Meal>>(meals);
        }

        public async Task<Meal> GetMealByIdAsync(int mealId)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(u => u.MealId == mealId);
            return _mapper.Map<Meal>(meal);
        }

        public async Task<bool> UpdateMealAsync(Meal meal)
        {
            var mealEntity = await _context.Meals.FindAsync(meal.MealId);
            if (mealEntity == null)
            {
                return false;
            }

            mealEntity.Name = meal.Name;
            mealEntity.Description = meal.Description;
            mealEntity.Price = meal.Price;
            mealEntity.AvailableQuantity = meal.AvailableQuantity;

            _context.Meals.Update(mealEntity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
