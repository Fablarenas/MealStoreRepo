using AutoMapper;
using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;

namespace MealManagement.Application.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<MealDto> AddMealAsync(MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            var mealInserted = await _mealRepository.AddMealAsync(meal);
            return _mapper.Map<MealDto>(mealInserted);
        }

        public async Task<bool> DeleteMealAsync(int mealId)
        {
            return await _mealRepository.DeleteMealAsync(mealId);
        }

        public async Task<List<MealDto>> GetAllAvaliableMeals()
        {
            var availableMeals = await _mealRepository.GetAllMealsAsync();
            return _mapper.Map<List<MealDto>>(availableMeals);
        }

        public Task<IEnumerable<MealDto>> GetAllMealsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MealDto> GetMealByIdAsync(int mealId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMealAsync(MealUpdateDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            return await _mealRepository.UpdateMealAsync(meal);
        }
    }
}
