namespace PizzaApi.DTO
{
    public class PizzaDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<int> IngredientIds { get; set; }
    }
}
