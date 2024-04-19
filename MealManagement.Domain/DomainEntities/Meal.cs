using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Domain.DomainEntities
{
        public class Meal
        {
            public int MealId { get; private set; }
            public string Name { get; private set; }
            public string Description { get; private set; }
            public decimal Price { get; private set; }
            public int AvailableQuantity { get; private set; }

            public bool DecreaseStock(int quantity)
            {
                if (AvailableQuantity >= quantity)
                {
                    AvailableQuantity -= quantity;
                    return true;
                }
                return false;
            }

            public bool IsAvaliable(int quantity)
            {
                if (AvailableQuantity >= quantity)
                {
                    return true;
                }
                return false;
            }

    }
}
