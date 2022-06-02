namespace CityApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new ReportIncidentPage();
	}
}
