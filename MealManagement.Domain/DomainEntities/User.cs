

namespace MealManagement.Domain.DomainEntities
{
    public class User
    {
        public User(string username, string email, string password, UserRole role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
        public int? UserId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public UserRole? Role { get; set; }

        public string Token { get; set; }

        public bool VerifyPassword(string providedPasswordHash)
        {
            return Password == providedPasswordHash;
        }

        public static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 8;
        }
    }

    public enum UserRole
    {
        Administrator,
        User
    }
}
