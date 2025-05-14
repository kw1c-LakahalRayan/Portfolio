using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitnessapp_thema9.Model;

namespace Fitnessapp_thema9.Services
{
    public class RecipeService
    {
        private readonly HttpClient _client; // HttpClient voor het uitvoeren van HTTP-aanroepen

        public RecipeService()
        {
            _client = new HttpClient(); // Maak een nieuwe instantie van HttpClient aan
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Stel de Accept-header in voor JSON-responses
        }

        public async Task<List<Recipe>> GetRecipes(string ingredient)
        {
            string apiKey = "9df9dce52974404bab4578fdbfa0c788"; // Je API-sleutel hier
            string url = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients={ingredient}&apiKey={apiKey}"; // Bouw de URL voor de API-aanroep

            var response = await _client.GetAsync(url); // Voer de GET-aanroep uit
            if (response.IsSuccessStatusCode) // Controleer of de respons succesvol is
            {
                var jsonResponse = await response.Content.ReadAsStringAsync(); // Lees de JSON-respons als string
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(jsonResponse); // Deserializeer de JSON-string naar een lijst van recepten
                return recipes; // Retourneer de lijst met recepten
            }

            return null; // Of gooi een foutmelding als er iets misgaat
        }
    }
}
