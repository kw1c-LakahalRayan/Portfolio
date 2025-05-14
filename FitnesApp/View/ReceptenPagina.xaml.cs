// ReceptenPagina.xaml.cs
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Fitnessapp_thema9.Model;

namespace Fitnessapp_thema9.View
{
    public partial class ReceptenPagina : ContentPage
    {
        public ReceptenPagina()
        {
            InitializeComponent(); // Initialiseren van de componenten van de receptenpagina
        }

        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            // Haal de zoekterm op van het invoerveld
            string zoekTerm = ZoekEntry.Text;

            // Logica om recepten op te halen op basis van de zoekterm
            List<Recipe> recepten = await ZoekReceptenAsync(zoekTerm);
            ReceptenCollectionView.ItemsSource = recepten; // Stel de opgehaalde recepten in als de bron voor de CollectionView
        }

        private async void OnViewRecipeButtonClicked(object sender, EventArgs e)
        {
            // Verkrijg de knop die is ingedrukt
            var button = sender as Button;

            // Verkrijg het recept dat aan de knop is gekoppeld als parameter
            var recipe = button.CommandParameter as Recipe;

            // Navigeer naar de detailpagina van het recept
            await Navigation.PushAsync(new RecipeDetailPage(recipe));
        }

        private async void OnSavedRecipesButtonClicked(object sender, EventArgs e)
        {
            // Navigeer naar de pagina met opgeslagen recepten
            await Navigation.PushAsync(new SavedRecipesPage());
        }

        private async Task<List<Recipe>> ZoekReceptenAsync(string zoekTerm)
        {
            var httpClient = new HttpClient(); // Maak een nieuwe HttpClient aan
            var apiKey = "05a617c5bff84e108475afcec7eb4c61"; // API-sleutel voor Spoonacular
            var url = $"https://api.spoonacular.com/recipes/complexSearch?query={zoekTerm}&number=10&apiKey={apiKey}"; // API-URL met zoekterm

            try
            {
                // Voer de GET-aanroep uit om recepten op te halen
                var response = await httpClient.GetStringAsync(url);

                // Deserialize de JSON-antwoord naar een RecipeResponse-object
                var recipesResponse = JsonConvert.DeserializeObject<RecipeResponse>(response);

                // Controleer of de results null zijn en geef dan een lege lijst terug
                return recipesResponse?.results ?? new List<Recipe>();
            }
            catch (HttpRequestException e)
            {
                // Log de foutmelding naar de console
                Console.WriteLine($"Error fetching recipes: {e.Message}");
                return new List<Recipe>(); // Return een lege lijst in geval van een fout
            }
        }

        // Klasse voor het deserialiseren van het API-antwoord
        public class RecipeResponse
        {
            public List<Recipe> results { get; set; }  // Zorg dat dit overeenkomt met de JSON-structuur
        }
    }
}
