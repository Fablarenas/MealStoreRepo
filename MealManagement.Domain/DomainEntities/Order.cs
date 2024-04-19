namespace MealManagement.Domain.DomainEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total
        {
            get
            {
                if (OrderDetails != null && OrderDetails.Meals != null)
                {
                    return OrderDetails.Meals.Sum(meal => meal.Subtotal);
                }
                return 0;
            }
        }
        public string Status { get; set; }
        public OrderDetails OrderDetails {  get; set; }
    }
}
