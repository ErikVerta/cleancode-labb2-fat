namespace Shared
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
