using MealManagement.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Domain.Repositories
{
    public interface IUserRepository
    {
            Task<User> GetUserByIdAsync(int userId);
            Task<User> GetUserByUsernameAsync(string username);
            Task AddUserAsync(User user);
        
    }
}
