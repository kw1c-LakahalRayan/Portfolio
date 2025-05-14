using Microsoft.Maui.Storage;

namespace Fitnessapp_thema9.View
{
    public partial class ProfielPagina : ContentPage
    {
        public ProfielPagina()
        {
            InitializeComponent(); // Initialiseren van de componenten van de pagina
            LoadProfielData(); // Laad de profielgegevens van de gebruiker
        }

        private void LoadProfielData()
        {
            try
            {
                // Ophalen van de voornaam en achternaam van de opgeslagen voorkeuren
                VoornaamLabel.Text = Preferences.Get("Voornaam", "Jan"); // Standaardwaarde "Jan"
                AchternaamLabel.Text = Preferences.Get("Achternaam", "Jansen"); // Standaardwaarde "Jansen"

                // Ophalen van de geboortedatum, met een standaardwaarde als deze niet is ingesteld
                string geboortedatumStr = Preferences.Get("Geboortedatum", DateTime.Now.ToString("O"));
                DateTime geboortedatum;

                // Controleren of de geboortedatum geldig kan worden geparsed
                if (DateTime.TryParse(geboortedatumStr, out geboortedatum))
                {
                    // Als de geboortedatum geldig is, toon deze in het juiste formaat
                    GeboortedatumLabel.Text = geboortedatum.ToString("dd-MM-yyyy");
                    LeeftijdLabel.Text = CalculateLeeftijd(geboortedatum).ToString(); // Bereken en toon de leeftijd
                }
                else
                {
                    // Toon "N/A" en "Onbekend" als de geboortedatum ongeldig is
                    GeboortedatumLabel.Text = "N/A";
                    LeeftijdLabel.Text = "Onbekend";
                }

                // Ophalen van gewicht en lengte met standaardwaarden
                GewichtLabel.Text = Preferences.Get("Gewicht", 70.0).ToString(); // Gewicht met standaardwaarde van 70.0
                LengteLabel.Text = Preferences.Get("Lengte", 180).ToString(); // Lengte met standaardwaarde van 180
            }
            catch (Exception ex)
            {
                // Toon een foutmelding als er een uitzondering optreedt
                DisplayAlert("Fout", $"Er is een fout opgetreden bij het laden van profielgegevens: {ex.Message}", "OK");
            }
        }

        private int CalculateLeeftijd(DateTime geboortedatum)
        {
            // Bereken de leeftijd op basis van de geboortedatum
            int leeftijd = DateTime.Now.Year - geboortedatum.Year;
            if (DateTime.Now.DayOfYear < geboortedatum.DayOfYear)
            {
                leeftijd--; // Verminder de leeftijd met 1 als de verjaardag dit jaar nog niet is geweest
            }
            return leeftijd; // Retourneer de berekende leeftijd
        }

        private async void OnBewerkenButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Navigeren naar de BewerkenProfiel pagina wanneer de bewerken-knop wordt ingedrukt
                await Shell.Current.GoToAsync("//BewerkenProfiel");
            }
            catch (Exception ex)
            {
                // Toon een foutmelding als er een uitzondering optreedt tijdens de navigatie
                await DisplayAlert("Fout", $"Er is een fout opgetreden: {ex.Message}", "OK");
            }
        }
    }
}
