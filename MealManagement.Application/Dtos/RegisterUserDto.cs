using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Application.Dtos
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRolDto Rol { get; set; }
    }

    public enum UserRolDto
    {
        Administrator,
        User
    }
}
