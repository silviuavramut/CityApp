using CityApp.Views;

namespace CityApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
        InitializeComponent();
	}

    private async void redirectAddIncident(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ReportIncidentPage());
    }

    private async void redirectPlacesToEat(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewRestaurantsPage());
    }
    private void redirectPlacesToSee(object sender, EventArgs e)
    {
        //todo
    }
}