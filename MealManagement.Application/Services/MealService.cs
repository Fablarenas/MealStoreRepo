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

        public Task AddMealAsync(MealDto mealDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMealAsync(int mealId)
        {
            throw new NotImplementedException();
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

        public Task UpdateMealAsync(MealDto mealDto)
        {
            throw new NotImplementedException();
        }
    }
}
