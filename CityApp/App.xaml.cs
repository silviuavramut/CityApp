namespace CityApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LandingPage())
		{
			BarBackgroundColor = Color.FromHex("#ff8a65"),
        };
	}
}
