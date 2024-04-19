using System.Text.Json.Serialization;


namespace MealManagement.Application.Dtos
{
    public class OrderDto
    {
        [JsonIgnore]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public MealOrderDto[]? OrderMeals { get; set; }

        [JsonIgnore]
        public DateTime OrderDate { get; set; }

        [JsonIgnore]
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
