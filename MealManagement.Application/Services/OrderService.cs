using AutoMapper;
using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;

namespace MealManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IMealRepository mealRepository, IMapper mapper, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public async Task<OrderCreatedDto> PlaceOrderAsync(OrderDto orderDto)
        {
            var user = await _userRepository.GetUserByIdAsync(orderDto.UserId);


            List<Meal> updatedMeals = new List<Meal>();

            var order = new Order
            {
                User = user,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderDetails = new OrderDetails()
            };

            foreach (var mealDto in orderDto.OrderMeals)
            {
                var meal = await _mealRepository.GetMealByIdAsync(mealDto.IdMeal);
                if (meal == null || !meal.IsAvaliable(mealDto.Quantity))
                {
                    return null;
                }

                meal.DecreaseStock(mealDto.Quantity);
                updatedMeals.Add(meal);

                var orderMeal = new OrderMeal(meal.MealId, mealDto.Quantity, meal.Price);
                order.OrderDetails.Meals.Add(orderMeal);
            }

            foreach (var meal in updatedMeals)
            {
                await _mealRepository.UpdateMealAsync(meal);
            }
            order.Status = "Confirmed";

            var orderCreated = await _orderRepository.CreateOrderAsync(order);
            return _mapper.Map<OrderCreatedDto>(orderCreated);
        }

    }
}
