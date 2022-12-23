namespace Shared
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int RecipeId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
    }
}
