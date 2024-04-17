using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Application.Services
{
    internal class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(password);
            var user = new User(username, email, hashedPassword);
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<LoginUserDto> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && _passwordHasher.VerifyHashedPassword(user.PasswordHash, password))
            {
                return new UserDto { Username = user.Username, Email = user.Email, Roles = user.Roles.Select(r => r.RoleName).ToList() };
            }
            return null;
        }
    }
}
