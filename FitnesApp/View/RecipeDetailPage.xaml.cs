// RecipeDetailPage.xaml.cs
using Microsoft.Maui.Storage;
using Fitnessapp_thema9.Model;
using Newtonsoft.Json;

namespace Fitnessapp_thema9.View
{
    public partial class RecipeDetailPage : ContentPage
    {
        private Recipe _recipe; // Private field om het recept op te slaan

        public RecipeDetailPage(Recipe recipe)
        {
            InitializeComponent(); // Initialiseer de componenten van de detailpagina
            _recipe = recipe; // Sla het meegegeven recept op in het private field
            BindingContext = _recipe; // Stel de binding context in op het recept voor databinding
        }

        private async void OnSaveRecipeButtonClicked(object sender, EventArgs e)
        {
            // Serialiseer het recept naar JSON
            var recipeJson = JsonConvert.SerializeObject(_recipe);
            string recipeKey = $"Recipe_{_recipe.Id}"; // Zorg ervoor dat je een unieke sleutel gebruikt voor het recept

            // Sla het recept op in de lokale opslag
            Preferences.Set(recipeKey, recipeJson);

            // Toon een bevestigingsmelding dat het recept succesvol is opgeslagen
            await DisplayAlert("Success", "Recipe saved!", "OK");
        }
    }
}
