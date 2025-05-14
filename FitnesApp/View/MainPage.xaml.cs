using Microsoft.Maui.Controls;

namespace Fitnessapp_thema9.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnNavigateToActiviteitenClicked(object sender, EventArgs e)
        {
            // navigeert naar de ActiviteitenPagina
            await Shell.Current.GoToAsync("activiteiten");
        }

        private async void OnNavigateToProfielClicked(object sender, EventArgs e)
        {
            // navigeert naar de ActiviteitenPagina
            await Shell.Current.GoToAsync("Profiel");
        } 
        
        private async void OnNavigateToReceptenClicked(object sender, EventArgs e)
        {
            // navigeert naar de ActiviteitenPagina
            await Shell.Current.GoToAsync("///recepten");
        }
    }
}
