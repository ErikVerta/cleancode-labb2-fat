namespace Shared
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
