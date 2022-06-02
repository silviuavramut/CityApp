namespace CityApp;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private async void Logout(object sender, EventArgs e)
    {

        await Navigation.PushModalAsync(new LandingPage());
    }
}