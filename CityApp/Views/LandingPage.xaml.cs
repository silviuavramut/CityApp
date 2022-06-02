namespace CityApp;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
    }

    private async void redirectRegister(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }

    private async void redirectLogin(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}