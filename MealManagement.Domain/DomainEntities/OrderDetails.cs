using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Domain.DomainEntities
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public List<OrderMeal> Meals { get; set; } = new List<OrderMeal>(); // Inicializa para evitar null

        public OrderDetails()
        {
            Meals = new List<OrderMeal>();
        }
    }
}
