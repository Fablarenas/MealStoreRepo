using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MealManagement.Application.Dtos
{
    public class OrderCreatedDto
    {
        public int OrderID { get; set; }
        public OrderCreatedDetailsDto orderCreatedDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderCreatedDetailsDto
    {
        public List<MealsOrderCreated> MealsOrderCreated { get; set; }
    }

    public class MealsOrderCreated {
        public int MealId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
