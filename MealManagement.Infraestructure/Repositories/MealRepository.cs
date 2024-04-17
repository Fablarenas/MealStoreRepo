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
        public async Task AddMealAsync(Meal meal)
        {
            var mealEntity = _mapper.Map<MealEntity>(meal);
            _context.Meals.Add(mealEntity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteMealAsync(int mealId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Meal>> GetAllMealsAsync()
        {
            var meals = await _context.Meals.ToListAsync();
            return _mapper.Map<List<Meal>>(meals);
        }

        public Task<Meal> GetMealByIdAsync(int mealId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMealAsync(Meal meal)
        {
            throw new NotImplementedException();
        }
    }
}
