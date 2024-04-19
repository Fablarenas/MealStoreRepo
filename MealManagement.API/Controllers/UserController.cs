using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

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

        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            try
            {
                var result = await _accountService.RegisterUserAsync(model);
                if (result)
                {
                    return Ok(new { message = "Registration successful" });
                }

                return BadRequest(new { message = "Registration failed" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
