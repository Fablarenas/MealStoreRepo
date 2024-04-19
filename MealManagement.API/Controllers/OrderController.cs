using MealManagement.Application.Dtos;
using MealManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MealManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto order)
        {
            var success = await _orderService.PlaceOrderAsync(order);
            if (success == null)
            {
                return BadRequest("Unable to place the order. Check the available quantity.");
            }
            return Ok(success);
        }
    }
}
