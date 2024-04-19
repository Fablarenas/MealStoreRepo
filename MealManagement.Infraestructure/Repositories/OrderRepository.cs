using AutoMapper;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;
using MealManagement.Infraestructure.DbContext;
using MealManagement.Infraestructure.Entities;


namespace MealManagement.Infraestructure.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly MealStoreContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(MealStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            var orderEntity = _mapper.Map<OrderEntity>(order);
            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Order>(orderEntity);
        }
    }
}
