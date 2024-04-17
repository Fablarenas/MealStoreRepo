using AutoMapper;
using MealManagement.Application.Dtos;
using MealManagement.Application.Exceptions;
using MealManagement.Application.Interfaces;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            var hashedPassword = _userRepository.HashPassword(password);

            if (!User.ValidatePasswordLength(password))
            {
                throw new RegisterUserException("Password must be at least 8 characters long.");
            }

            var user = new User(username, email, hashedPassword);
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<UserDto> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && _userRepository.VerifyPassword(user.Password, password))
            {
                return _mapper.Map<UserDto>(user);
            }
            return null;
        }
    }
}
