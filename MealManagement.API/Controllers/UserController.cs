using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MealManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _accountService;

        public UserController(IUserService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            var result = await _accountService.RegisterUserAsync(model.UserName, model.Email, model.Password);
            if (result)
                return Ok(new { message = "Registration successful" });

            return BadRequest(new { message = "Registration failed" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            var user = await _accountService.AuthenticateUserAsync(model.UserName, model.Password);
            if (user != null)
                return Ok(user);

            return Unauthorized(new { message = "Username or password is incorrect" });
        }
    }
}
