using Microsoft.Maui.Storage;

namespace Fitnessapp_thema9.View
{
    public partial class BewerkenProfiel : ContentPage
    {
        public BewerkenProfiel()
        {
            InitializeComponent(); // Initialiseren van de componenten van de pagina
            LoadProfielData(); // Laadt bestaande gegevens om te bewerken
        }

        private void LoadProfielData()
        {
            // Laadt de opgeslagen gegevens van de gebruiker en vult de invoervelden
            VoornaamEntry.Text = Preferences.Get("Voornaam", "Jan"); // Voornaam met standaardwaarde "Jan"
            AchternaamEntry.Text = Preferences.Get("Achternaam", "Jansen"); // Achternaam met standaardwaarde "Jansen"
            GeboortedatumEntry.Text = Preferences.Get("Geboortedatum", new DateTime(1990, 1, 1).ToString("dd-MM-yyyy")); // Geboortedatum met standaardwaarde
            GewichtEntry.Text = Preferences.Get("Gewicht", 70.0).ToString(); // Gewicht met standaardwaarde van 70.0
            LengteEntry.Text = Preferences.Get("Lengte", 180).ToString(); // Lengte met standaardwaarde van 180
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Profielgegevens opslaan in de voorkeuren
                Preferences.Set("Voornaam", VoornaamEntry.Text); // Opslaan van voornaam
                Preferences.Set("Achternaam", AchternaamEntry.Text); // Opslaan van achternaam

                DateTime geboortedatum; // Declaratie van geboortedatum variabele
                if (DateTime.TryParse(GeboortedatumEntry.Text, out geboortedatum))
                {
                    // Als de geboortedatum geldig is, wordt deze opgeslagen
                    Preferences.Set("Geboortedatum", geboortedatum.ToString("O"));
                }
                else
                {
                    // Toont foutmelding als de geboortedatum ongeldig is
                    await DisplayAlert("Fout", "Ongeldige geboortedatum.", "OK");
                    return;
                }

                // Valideerd en sla gewicht en lengte op
                if (double.TryParse(GewichtEntry.Text, out double gewicht) && double.TryParse(LengteEntry.Text, out double lengte))
                {
                    Preferences.Set("Gewicht", gewicht); // Opslaan van gewicht
                    Preferences.Set("Lengte", lengte); // Opslaan van lengte
                }
                else
                {
                    // Toont foutmelding als gewicht of lengte ongeldig zijn
                    await DisplayAlert("Fout", "Ongeldige waarde voor gewicht of lengte.", "OK");
                    return;
                }

                // navigeert naar de ProfielPagina na opslaan
                await Shell.Current.GoToAsync("//Profiel");
            }
            catch (Exception ex)
            {
                // Toont een foutmelding als er een uitzondering optreedt
                await DisplayAlert("Fout", $"Er is een fout opgetreden: {ex.Message}", "OK");
            }
        }
    }
}
