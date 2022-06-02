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
}