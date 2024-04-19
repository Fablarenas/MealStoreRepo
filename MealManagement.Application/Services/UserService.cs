using AutoMapper;
using MealManagement.Application.Dtos;
using MealManagement.Application.Exceptions;
using MealManagement.Application.Interfaces;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;

namespace MealManagement.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto userDto)
        {
            var hashedPassword = _userRepository.HashPassword(userDto.Password);

            if (!User.ValidatePasswordLength(userDto.Password))
            {
                throw new RegisterUserException("Password must be at least 8 characters long.");
            }

            var user = new User(userDto.UserName, userDto.Email, hashedPassword , (UserRole)userDto.Rol);
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<UserLoggedDto> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && _userRepository.VerifyPassword(password, user.Password))
            {
                var userLogged = _userRepository.CreateToken(user);
                return _mapper.Map<UserLoggedDto>(userLogged);
            }

            return null;
        }

    }
}
