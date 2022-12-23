using System.Text.Json.Serialization;

namespace Shared
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Pizza>? Pizzas { get; set; }
    }
}
