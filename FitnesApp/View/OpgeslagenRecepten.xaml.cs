// SavedRecipesPage.xaml.cs
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Fitnessapp_thema9.Model;

namespace Fitnessapp_thema9.View
{
    public partial class SavedRecipesPage : ContentPage
    {
        public SavedRecipesPage()
        {
            InitializeComponent();
            LoadSavedRecipes();
        }

        private void LoadSavedRecipes()
        {
            // Lijst om de opgeslagen recepten te bewaren
            List<string> savedRecipes = new List<string>();

            // Hier voegen we gewoon een voorbeeld sleutel toe
            for (int i = 0; i < 10; i++)
            {
                var recipe = Preferences.Get($"recipe_{i}", null);
                if (recipe != null)
                {
                    savedRecipes.Add(recipe); // Voeg het recept toe aan de lijst
                }
            }

            // Toont de recepten in de ListView
            RecipesListView.ItemsSource = savedRecipes;
        }

        private async void OnViewRecipeButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var recipe = button.CommandParameter as Recipe;

            // Navigeer naar de detailpagina van het recept
            await Navigation.PushAsync(new RecipeDetailPage(recipe));
        }
    }
}
