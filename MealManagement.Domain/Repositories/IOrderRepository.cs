using MealManagement.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order meal);
    }
}
