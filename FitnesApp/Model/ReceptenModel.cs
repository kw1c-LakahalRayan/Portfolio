using Newtonsoft.Json;

namespace Fitnessapp_thema9.Model
{
    public class Recipe
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public List<Ingredient>? MissedIngredients { get; set; }
    }

    public class Ingredient
    {
        public string? Name { get; set; }
        public double? Amount { get; set; }
        public string? Unit { get; set; }
    }

    public class RecipeResponse
    {
        [JsonProperty("results")]
        public List<Recipe>? Results { get; set; }
    }
}
