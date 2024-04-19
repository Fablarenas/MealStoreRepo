using AutoMapper;
using MealManagement.Domain.DomainEntities;
using MealManagement.Domain.Repositories;
using MealManagement.Infraestructure.DbContext;
using MealManagement.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealManagement.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MealStoreContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserRepository(MealStoreContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public User CreateToken(User user){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
