using MealManagement.Domain.DomainEntities;

namespace MealManagement.Domain.Repositories
{
    public interface IUserRepository
    {
            Task<User> GetUserByIdAsync(int userId);
            Task<User> GetUserByUsernameAsync(string username);
            Task AddUserAsync(User user);
            string HashPassword(string password);
            bool VerifyPassword(string password, string hashedPassword);
    }
}
