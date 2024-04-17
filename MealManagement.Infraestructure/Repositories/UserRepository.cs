using AutoMapper;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;
using MealManagement.Infraestructure.DbContext;
using MealManagement.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealManagement.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MealStoreContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MealStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            return _mapper.Map<User>(user);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return _mapper.Map<User>(user);
        }

        public async Task AddUserAsync(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
        }
    }

}
