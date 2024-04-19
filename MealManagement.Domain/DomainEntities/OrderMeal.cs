namespace MealManagement.Domain.DomainEntities
{
    public class OrderMeal
    {
        public int OrderDetailId { get; set; }
        public int MealId { get; private set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        public OrderMeal(int mealId, int quantity, decimal unitPrice)
        {
            MealId = mealId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }

}
