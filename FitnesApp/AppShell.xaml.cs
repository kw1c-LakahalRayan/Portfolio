using Fitnessapp_thema9.View;
using Microsoft.Maui.Controls;

namespace Fitnessapp_thema9
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registreer routes voor navigatie
            Routing.RegisterRoute("home", typeof(MainPage));
            Routing.RegisterRoute("activiteiten", typeof(ActiviteitenPagina));
            Routing.RegisterRoute("Profiel", typeof(ProfielPagina));
        }
    }
}